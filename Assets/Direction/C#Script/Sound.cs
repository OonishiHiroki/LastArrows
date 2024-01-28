using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    private AudioSource audioSource;

    //SE���󂯎���Ă���
    [SerializeField] private AudioClip se;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource�R���|�[�l���g�̎擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���N���b�N�������ɉ����Ȃ�
        if (Input.GetMouseButtonUp(0))
        {
            //�����̃N���b�v���Đ�
            audioSource.PlayOneShot(se);
        }
    }
}
