using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //HP�Ǘ�
        if (HP <= 0)
        {
            //�����ŏ�����
            Destroy(this.gameObject);
        }
    }
}
