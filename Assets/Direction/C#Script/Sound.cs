using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    private AudioSource audioSource;

    //SEを受け取っておく
    [SerializeField] private AudioClip se;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントの取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックした時に音がなる
        if (Input.GetMouseButtonUp(0))
        {
            //引数のクリップを再生
            audioSource.PlayOneShot(se);
        }
    }
}
