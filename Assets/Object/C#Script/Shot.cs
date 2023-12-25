using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shot : MonoBehaviour
{

    //ゲームオブジェクトをインスペクターから参照するための変数
    public GameObject Bullet;
    float speed;
    public static bool isdestroyed;
    private int count;

    public Text shellLabel;

    // Start is called before the first frame update

    void Start()
    {
        count = 7;
        speed = 700.0f;
        isdestroyed = true;
        shellLabel.text = "砲弾 : " + count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Vector3 mousePosition = Input.mousePosition;

            if (mousePosition.y <= 970)
            {
                if (isdestroyed == true)
                {
                    if (Input.GetMouseButtonUp(0) && count > 0)
                    {

                        //弾を生成する
                        GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);

                        Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();
                        cloneRigidbody.AddForce(-transform.forward * speed);

                        count--;

                        shellLabel.text = "砲弾 : " + count;

                        isdestroyed = false;
                    }
                }
            }
        }
    }
}
