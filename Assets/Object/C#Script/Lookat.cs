using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    Plane plane = new Plane();

    //playerController player = new playerController();

    float distance = 0;

    [System.Obsolete]
    void Start()
    {
        //LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        //���̕�
        //renderer.SetWidth(0.1f, 0.1f);
        //���_�̐�
        //renderer.SetVertexCount(2);
        //���_�̐ݒ�
        //renderer.SetPosition(0, player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            //�J�����ƃ}�E�X�̈ʒu������Ray������
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //�v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
            plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
            if (plane.Raycast(ray, out distance))
            {
                //���������Ɍ�_���Z�o���āA��_�̕�������
                var lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);
            }
        }
    }
}
