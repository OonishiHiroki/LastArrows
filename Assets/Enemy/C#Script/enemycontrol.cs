using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemycontrol : MonoBehaviour
{

    //public ShakeByPerlinNoise shakeByPerlinNoise;
    public CameraShake cameraShake;

    //ˆÚ“®•Ï”
    public float speed;
    private Vector3 pos;

    //“G‚ÌHPŠÇ—
    private int enemyHP;

    //GameObjectŒ^‚ğ•Ï”tatget‚ÅéŒ¾‚µ‚Ü‚·
    public GameObject target;

    //SE
    private AudioSource audioSource;
    [SerializeField] private AudioClip se;

    //‹üŠÇ—
    public float m_fsightAngle = 45.0f;

    //©‹@‚É’e‚ğ”­Ë‚·‚é(•Ï”éŒ¾)
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
        //HPŠÇ—
        if (enemyHP <= 0)
        {
            //©•ª‚ÅÁ‚¦‚é
            Destroy(this.gameObject, 0.5f);
            //speed = 0.0f;
        }


        //ˆÚ“®
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

        ///-----©‹@‚ğ’Ç‚¤-----///

        //Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1.0f);

        ////“G‚ª’Ç‚Á‚Ä‚­‚é‘¬‚³‚ğŒˆ‚ß‚é
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

    //“G‚Ìƒ_ƒ[ƒWŠÖ”
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
                        //Debug.Log("‹ŠE‚Ì”ÍˆÍ“à&‹ŠE‚ÌŠp“x“à&áŠQ•¨‚È‚µ");

                        //©‹@‚ÉŒü‚©‚Á‚Ä’e‚ğ”­Ë‚·‚é
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
