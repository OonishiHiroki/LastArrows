using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// パーリンノイズ値を使用した揺れ
/// </summary>
public class ShakeByPerlinNoise : MonoBehaviour
{

    private struct ShakeInfo
    {
        public ShakeInfo(float duration, float strength, float vibrato, Vector2 randomOffset)
        {
            Duration = duration;
            Strength = strength;
            Vibrato = vibrato;
            RandomOffset = randomOffset;
        }

        public float Duration;          //時間
        public float Strength;          //揺れの大きさ
        public float Vibrato;           //どのくらい振動するか
        public Vector2 RandomOffset;    //ランダムオフセット値
    }

    private ShakeInfo _ShakeInfo;

    private Vector3 _initPosition;       //初期位置
    private bool _isDoShake;            //揺れ実行中か
    private float _totalShakeTime;      //揺れ経過時間

    // Start is called before the first frame update
    void Start()
    {
        _initPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDoShake) return;

        //揺れ位置情報更新
        gameObject.transform.position = GetUpdateShakePosition(_ShakeInfo, _totalShakeTime, _initPosition);

        //duration分の時間が経過したら揺らすのをやめる
        _totalShakeTime += Time.deltaTime;
        if(_totalShakeTime >= _ShakeInfo.Duration)
        {
            _isDoShake = false;
            _totalShakeTime = 0.0f;
            //初期位置に戻す
            gameObject.transform.position = _initPosition;
        }
    }

    /// <summary>
    /// 更新後の揺れ位置を取得
    /// </summary>
    /// <param name="shakeInfo">揺れ位置</param>
    /// <param name="totalTime">経過時間</param>
    /// <param name="initPostion">初期位置</param>
    /// <returns>更新後の揺れ位置</returns>
    private Vector3 GetUpdateShakePosition(ShakeInfo shakeInfo, float totalTime, Vector3 initPostion)
    {
        //パーリンノイズ値(-1.0~1.0)を取得
        var strength = shakeInfo.Strength;
        var randomOffset = shakeInfo.RandomOffset;
        var randomX = GetPerlinNoiseValue(randomOffset.x, strength, totalTime);
        var randomY = GetPerlinNoiseValue(randomOffset.y, strength, totalTime);

        //-strength ~　strenghtの値に変換
        randomX *= strength;
        randomY *= strength;

        //-vibrato ~ vibratoの値に変換
        var vibrato = shakeInfo.Vibrato;
        var ratio = 1.0f - totalTime / shakeInfo.Duration;
        vibrato *= ratio;
        randomX = Mathf.Clamp(randomX, -vibrato, vibrato);
        randomY = Mathf.Clamp(randomY, -vibrato, vibrato);

        //初期位置を加える形で設定する
        var position = _initPosition;
        position.x += randomX;
        position.y += randomY;
        return position;
    }

    /// <summary>
    /// パーリンノイズ値を取得
    /// </summary>
    /// <param name="offset">オフセット値</param>
    /// <param name="speed">速度</param>
    /// <param name="time">時間</param>
    /// <returns></returns>
    private float GetPerlinNoiseValue(float offset, float speed, float time)
    {
        //パーリンノイズを取得する
        //X : オフセット値　+ 速度 + 時間
        //Y : 0.0固定
        var perlinNoise = Mathf.PerlinNoise(offset + speed + time, 0.0f);
        //0.0 ~ 1.0 -> -1.0 ~ 1.0に変換して返却
        return (perlinNoise - 0.5f) * 2.0f;
    }

    /// <summary>
    /// 揺れ開始
    /// </summary>
    /// <param name="duration">時間</param>
    /// <param name="strength">揺れの強さ</param>
    /// <param name="vibrato">どのくらい振動するか</param>
    public void StartShake(float duration, float strength, float vibrato)
    {
        var randomOffset = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f)); //ランダム値はとりあえず0~100で設定
        _ShakeInfo = new ShakeInfo(duration, strength, vibrato, randomOffset);
        _isDoShake = true;
        _totalShakeTime = 0.0f;
    }
}
