using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class resultDirection : MonoBehaviour
{
    
    //定義領域
    private Animator anim;
    private GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //敵が全員倒されたら
        if (enemy.Length == 0)
        {
            //Bool型のパラメータであるdeleteEnemyをTrueにする
            anim.SetBool("deleteEnemy", true);
        }

    }
}
