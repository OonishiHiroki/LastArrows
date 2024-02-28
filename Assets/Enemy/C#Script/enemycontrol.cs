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

    //SE
    private AudioSource audioSource;
    [SerializeField] private AudioClip se;

    //�����Ǘ�
    public float m_fsightAngle = 45.0f;

    //���@�ɒe�𔭎˂���(�ϐ��錾)
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;

    private float ballSpeed = 10.0f;
    private float time = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 1;
        speed = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //HP�Ǘ�
        if (enemyHP <= 0)
        {
            //�����ŏ�����
            Destroy(this.gameObject, 0.5f);
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

        ///-----���@��ǂ�-----///

        //Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1.0f);

        ////�G���ǂ��Ă��鑬�������߂�
        //Vector3 p = new Vector3(0.0f, 0.0f, 0.05f);

        //transform.Translate(p);

        ///-----------------------///
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
            this.GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject, 3.0f);
        }
    }

    //�G�̃_���[�W�֐�
    public void Damage()
    {
        enemyHP -= 1;
        audioSource.PlayOneShot(se);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 posDelta = other.transform.position - transform.position;
            float targetAngle = Vector3.Angle(transform.forward, posDelta);
            if (targetAngle < m_fsightAngle)
            {
                if (Physics.Raycast(transform.position, posDelta, out RaycastHit hit))
                {
                    if (hit.collider == other)
                    {
                        //Debug.Log("���E�͈͓̔�&���E�̊p�x��&��Q���Ȃ�");

                        //���@�Ɍ������Ēe�𔭎˂���
                        transform.LookAt(player.transform.transform);
                        time -= Time.deltaTime;
                        if(time <= 0)
                        {
                            BallShot();
                            time = 1.0f;
                        }
                    }
                }
            }
        }
    }

    void BallShot()
    {
        GameObject shotObj = Instantiate(ball, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
    }
}
