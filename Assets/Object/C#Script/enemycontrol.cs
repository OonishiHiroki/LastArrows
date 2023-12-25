using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemycontrol : MonoBehaviour
{

    //public ShakeByPerlinNoise shakeByPerlinNoise;
    public CameraShake cameraShake;

    //�ړ��ϐ�
    public float speed;
    private Vector3 pos;

    //�G��HP�Ǘ�
    private int enemyHP;

    //GameObject�^��ϐ�tatget�Ő錾���܂�
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 1;
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //HP�Ǘ�
        if (enemyHP <= 0)
        {
            //�����ŏ�����
            Destroy(this.gameObject,0.5f);
            //speed = 0.0f;
        }


        //�ړ�
        pos = transform.position;

        transform.Translate(transform.right * Time.deltaTime * 3 * speed);

        if (pos.x > 5)
        {
            speed = -1;
        }
        if (pos.x < -5)
        {
            speed = 1;
        }

        //Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //Vector3 p = new Vector3(0.0f, 0.0f, 0.05f);

        //transform.Translate(p);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
            this.GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject,3.0f);
        }
    }

    public void Damage()
    {
        //shakeByPerlinNoise.StartShake(1.0f, 30.0f, 30.0f);
        enemyHP -= 1;
    }
}
