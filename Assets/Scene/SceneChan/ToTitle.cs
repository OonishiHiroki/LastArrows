using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{

    public FadeSceneLoader fadeSceneLoader;

    //�o�ߎ��ԃJ�E���g�p
    private float step_time;

    // Start is called before the first frame update
    void Start()
    {
        //�o�ߎ��ԏ����l
        step_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        //3�b��ɉ�ʑJ��
        if(step_time >= 5.0f)
        {
           fadeSceneLoader.CallFadeOutCoroutine("Level1");
        }
    }
}
