using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemy;
    public GameObject clearText;
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        clearText.SetActive(false);
        nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length == 0)
        {
            clearText.SetActive(true);
            nextButton.SetActive(true);
            //SceneManager.LoadScene("Level2");
        }
    }
}
