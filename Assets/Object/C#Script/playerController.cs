using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //�J�����V�F�C�N
    public CameraShake cameraShake;

    //public ShakeByPerlinNoise shakeByPerlinNoise;

    public float power = 1.0f;
    //public Rigidbody _rigidbody;
    //private float movementX;
    //private float movementZ;
    //private Vector3 movement;

    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBottom;

    //�J�������猩����ʉE��̍��W������ϐ�
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();

        ////�J�����ƃv���C���[�̋����𑪂�
        //var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        ////�X�N���[����ʍ����̈ʒu��ݒ肷��
        //LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        ////�X�N���[����ʉE��̈ʒu��ݒ肷��
        //RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(cameraShake.Shake(0.2f, 0.2f));
            //shakeByPerlinNoise.StartShake(1.0f, 30.0f, 30.0f);
            //Debug.Log("yeah");
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //_rigidbody.AddForce(new Vector3(0, 0, 1) * power);
        //    transform.position += power * transform.forward * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //_rigidbody.AddForce(new Vector3(-1, 0, 0) * power);
        //    transform.position -= power * transform.right * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    //_rigidbody.AddForce(new Vector3(0, 0, -1) * power);
        //    transform.position -= power * transform.forward * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    // _rigidbody.AddForce(new Vector3(1, 0, 0) * power);
        //    transform.position += power * transform.right * Time.deltaTime;
        //}
    }
}
