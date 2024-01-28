using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject confirmationPanel;
    // Start is called before the first frame update
    void Start()
    {
        //確認パネルを非表示
        confirmationPanel.SetActive(false);
    }

    //確認
    public void confirmation()
    {
        confirmationPanel.SetActive(true);
    }

    //ゲーム終了
    public void End()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
