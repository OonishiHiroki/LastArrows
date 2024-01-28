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
    //�����蔻��p�֐�
    void OnTriggerEnter(Collider other)
    {
        //�������������I�u�W�F�N�g�̃^�O��Enemy��������
        if (other.gameObject.tag == "Enemy")
        {
            //�e���������Ă���
            Destroy(this.gameObject);
            Shot.count -= 1;
            other.GetComponent<enemycontrol>().Damage();
            Shot.isdestroyed = true;
        }

        //�������������I�u�W�F�N�g���^�O��Obstacle��������
        if (other.gameObject.tag == "Obstacle")
        {
            //�e���������Ă���
            Shot.count -= 1;
            other.GetComponent<ParticleSystem>().Play();
            Shot.isdestroyed = true;
            Destroy(this.gameObject);
        }

        //�������������I�u�W�F�N�g���^�O��Wall��������
        if (other.gameObject.tag == "Wall")
        {
            //�e���������Ă���
            Shot.count -= 1;
            Shot.isdestroyed = true;
            Destroy(this.gameObject);
        }
    }

}
