using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// �p�[�����m�C�Y�l���g�p�����h��
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

        public float Duration;          //����
        public float Strength;          //�h��̑傫��
        public float Vibrato;           //�ǂ̂��炢�U�����邩
        public Vector2 RandomOffset;    //�����_���I�t�Z�b�g�l
    }

    private ShakeInfo _ShakeInfo;

    private Vector3 _initPosition;       //�����ʒu
    private bool _isDoShake;            //�h����s����
    private float _totalShakeTime;      //�h��o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        _initPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDoShake) return;

        //�h��ʒu���X�V
        gameObject.transform.position = GetUpdateShakePosition(_ShakeInfo, _totalShakeTime, _initPosition);

        //duration���̎��Ԃ��o�߂�����h�炷�̂���߂�
        _totalShakeTime += Time.deltaTime;
        if(_totalShakeTime >= _ShakeInfo.Duration)
        {
            _isDoShake = false;
            _totalShakeTime = 0.0f;
            //�����ʒu�ɖ߂�
            gameObject.transform.position = _initPosition;
        }
    }

    /// <summary>
    /// �X�V��̗h��ʒu���擾
    /// </summary>
    /// <param name="shakeInfo">�h��ʒu</param>
    /// <param name="totalTime">�o�ߎ���</param>
    /// <param name="initPostion">�����ʒu</param>
    /// <returns>�X�V��̗h��ʒu</returns>
    private Vector3 GetUpdateShakePosition(ShakeInfo shakeInfo, float totalTime, Vector3 initPostion)
    {
        //�p�[�����m�C�Y�l(-1.0~1.0)���擾
        var strength = shakeInfo.Strength;
        var randomOffset = shakeInfo.RandomOffset;
        var randomX = GetPerlinNoiseValue(randomOffset.x, strength, totalTime);
        var randomY = GetPerlinNoiseValue(randomOffset.y, strength, totalTime);

        //-strength ~�@strenght�̒l�ɕϊ�
        randomX *= strength;
        randomY *= strength;

        //-vibrato ~ vibrato�̒l�ɕϊ�
        var vibrato = shakeInfo.Vibrato;
        var ratio = 1.0f - totalTime / shakeInfo.Duration;
        vibrato *= ratio;
        randomX = Mathf.Clamp(randomX, -vibrato, vibrato);
        randomY = Mathf.Clamp(randomY, -vibrato, vibrato);

        //�����ʒu��������`�Őݒ肷��
        var position = _initPosition;
        position.x += randomX;
        position.y += randomY;
        return position;
    }

    /// <summary>
    /// �p�[�����m�C�Y�l���擾
    /// </summary>
    /// <param name="offset">�I�t�Z�b�g�l</param>
    /// <param name="speed">���x</param>
    /// <param name="time">����</param>
    /// <returns></returns>
    private float GetPerlinNoiseValue(float offset, float speed, float time)
    {
        //�p�[�����m�C�Y���擾����
        //X : �I�t�Z�b�g�l�@+ ���x + ����
        //Y : 0.0�Œ�
        var perlinNoise = Mathf.PerlinNoise(offset + speed + time, 0.0f);
        //0.0 ~ 1.0 -> -1.0 ~ 1.0�ɕϊ����ĕԋp
        return (perlinNoise - 0.5f) * 2.0f;
    }

    /// <summary>
    /// �h��J�n
    /// </summary>
    /// <param name="duration">����</param>
    /// <param name="strength">�h��̋���</param>
    /// <param name="vibrato">�ǂ̂��炢�U�����邩</param>
    public void StartShake(float duration, float strength, float vibrato)
    {
        var randomOffset = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f)); //�����_���l�͂Ƃ肠����0~100�Őݒ�
        _ShakeInfo = new ShakeInfo(duration, strength, vibrato, randomOffset);
        _isDoShake = true;
        _totalShakeTime = 0.0f;
    }
}
