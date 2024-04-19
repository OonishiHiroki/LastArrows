using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shot : MonoBehaviour
{

    //�Q�[���I�u�W�F�N�g���C���X�y�N�^�[����Q�Ƃ��邽�߂̕ϐ�
    public GameObject Bullet;

    //���̑���
    float speed;

    //�e�������Ă��玟�̒e���o��悤��
    public static bool isdestroyed;

    //�e��
    public static int count;

    //�����̃I�u�W�F�N�g��enemy�Ƃ������O�̕ϐ������
    private GameObject[] enemy;

    //�e���̕\��
    public Text shellLabel;

    //SE
    private AudioSource audioSource;
    //�������󂯎��
    [SerializeField] private AudioClip se;

    //�A�j���[�V����
    private Animator anim;

    // Start is called before the first frame update

    void Start()
    {
        count = 7;
        speed = 500.0f;
        isdestroyed = true;
        shellLabel.text = "�C�e : " + count;
        audioSource = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //������t���O��False�ɂ���
        anim.SetBool("isShot", false);

        //enemy�ϐ���gameObject�̃^�O"Enemy"��������
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //���Ԃ������Ă���Ȃ�
        if (Time.timeScale == 1)
        {
            Vector3 mousePosition = Input.mousePosition;

            //�G�̐���0�ȊO�Ȃ�
            if (enemy.Length != 0)
            {
                //�}�E�X�̈ʒu��970�ȉ��Ȃ�
                if (mousePosition.y <= 970)
                {
                    //�e�������Ă���Ȃ�
                    if (isdestroyed == true)
                    {
                        //�}�E�X�̍��N���b�N�������Ă��鏮���e�e��0���傫���Ȃ�
                        if (Input.GetMouseButtonUp(0) && count > 0)
                        {
                            anim.SetBool("isShot", true);
                            //����炷
                            audioSource.PlayOneShot(se);
                            //�e�𐶐�����
                            GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);

                            Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();
                            cloneRigidbody.AddForce(-transform.forward * speed);

                            //�e����ʂɏo�Ă���
                            isdestroyed = false;
                        }
                    }
                }
            }
            //�e���̕\��
            shellLabel.text = "�C�e : " + count;
        }
    }
}
