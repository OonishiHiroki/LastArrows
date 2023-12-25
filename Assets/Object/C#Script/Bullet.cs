using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //float speed;
    // Start is called before the first frame update
    void Start()
    {
        //speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,3.0f);
    }
    //当たり判定用関数
    void OnTriggerEnter(Collider other)
    {

        //もし当たったオブジェクトのタグがEnemyだったら
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemycontrol>().Damage();
            Shot.isdestroyed = true;
            Destroy(this.gameObject);
        }

        //もし当たったオブジェクトがタグがObstacleだったら
        if (other.gameObject.tag == "Obstacle")
        {
            other.GetComponent<ParticleSystem>().Play();
            Shot.isdestroyed = true;
            Destroy(this.gameObject);
        }

        //もし当たったオブジェクトがタグがWallだったら
        if (other.gameObject.tag == "Wall")
        {
            Shot.isdestroyed = true;
            Destroy(this.gameObject);
        }
    }

}
