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
        //HP管理
        if (HP <= 0)
        {
            //自分で消える
            Destroy(this.gameObject);
        }
    }
}
