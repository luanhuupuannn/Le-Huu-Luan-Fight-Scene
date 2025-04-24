using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLevel : MonoBehaviour
{
    int intLevel;
    public TextMeshProUGUI textLevel;
    public GameObject panelWin;




    private void Start()
    {
        intLevel = PlayerPrefs.GetInt("level");
        textLevel.text = "Lv " + intLevel;
    }
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            panelWin.SetActive(true);
        }
    }
}

   
