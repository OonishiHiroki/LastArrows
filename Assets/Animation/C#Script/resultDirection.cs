using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class resultDirection : MonoBehaviour
{
    
    //��`�̈�
    private Animator anim;
    private GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //�G���S���|���ꂽ��
        if (enemy.Length == 0)
        {
            //Bool�^�̃p�����[�^�ł���deleteEnemy��True�ɂ���
            anim.SetBool("deleteEnemy", true);
        }

    }
}
