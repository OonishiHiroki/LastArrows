using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverAnimation : MonoBehaviour
{
    private Animator anim;
    private GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (Shot.count == 0)
        {
            if (enemy.Length != 0)
            {
                anim.SetBool("blAnim", true);
            }
        }
    }
}
