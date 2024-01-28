using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    //UI
    private GameObject[] enemy;
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemy.Length == 0)
        {
            nextButton.SetActive(true);
            //SceneManager.LoadScene("Level2");
        }
    }
}
