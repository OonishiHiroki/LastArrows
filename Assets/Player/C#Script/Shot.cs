using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shot : MonoBehaviour
{

    //ゲームオブジェクトをインスペクターから参照するための変数
    public GameObject Bullet;

    //球の速さ
    float speed;

    //弾が消えてから次の弾が出るように
    public static bool isdestroyed;

    //弾数
    public static int count;

    //複数のオブジェクトにenemyという名前の変数を作る
    private GameObject[] enemy;

    //弾数の表示
    public Text shellLabel;

    //SE
    private AudioSource audioSource;
    //音声を受け取る
    [SerializeField] private AudioClip se;

    //アニメーション
    private Animator anim;

    // Start is called before the first frame update

    void Start()
    {
        count = 7;
        speed = 500.0f;
        isdestroyed = true;
        shellLabel.text = "砲弾 : " + count;
        audioSource = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //矢を撃つフラグをFalseにする
        anim.SetBool("isShot", false);

        //enemy変数にgameObjectのタグ"Enemy"を見つける
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //時間が動いているなら
        if (Time.timeScale == 1)
        {
            Vector3 mousePosition = Input.mousePosition;

            //敵の数が0以外なら
            if (enemy.Length != 0)
            {
                //マウスの位置が970以下なら
                if (mousePosition.y <= 970)
                {
                    //弾が消えているなら
                    if (isdestroyed == true)
                    {
                        //マウスの左クリックを押している尚且つ銃弾が0より大きいなら
                        if (Input.GetMouseButtonUp(0) && count > 0)
                        {
                            anim.SetBool("isShot", true);
                            //音を鳴らす
                            audioSource.PlayOneShot(se);
                            //弾を生成する
                            GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);

                            Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();
                            cloneRigidbody.AddForce(-transform.forward * speed);

                            //弾が画面に出ている
                            isdestroyed = false;
                        }
                    }
                }
            }
            //弾数の表示
            shellLabel.text = "砲弾 : " + count;
        }
    }
}
