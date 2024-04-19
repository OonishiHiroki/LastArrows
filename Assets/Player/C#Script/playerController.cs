using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //public ShakeByPerlinNoise shakeByPerlinNoise;

    public float power = 1.0f;

    //�A�j���[�V����
    private Animator anim;

    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBottom;

    //�J�������猩����ʉE��̍��W������ϐ�
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isForward", false);
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isBack", false);
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isForward", true);
            transform.position += power * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isLeft", true);
            transform.position -= power * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isBack", true);
            transform.position -= power * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRight", true);
            transform.position += power * transform.right * Time.deltaTime;
        }
    }
}
