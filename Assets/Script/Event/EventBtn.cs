using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;


public class EventBtn : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelInstruct;

    int intLevel = 1;


    
    public void Menu()
    {
        Time.timeScale = 1;
        intLevel = 1;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(0);
    }
    public void Play1v1()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(1);
    }
    public void Play1v2()
    {
        Time.timeScale = 0;

        SceneManager.LoadScene(2);
    }
    public void Play2v2()
    {
        Time.timeScale = 0;

        SceneManager.LoadScene(3);
    }
    public void PlayAgain1v1()
    {
        Time.timeScale = 0;
        intLevel=1;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(1);
    }
    public void PlayAgain1v2()
    {
        Time.timeScale = 0;
        intLevel = 1;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(2);
    }
    public void PlayAgain2v2()
    {
        Time.timeScale = 0;
        intLevel = 1;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(3);
    }
    public void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        panelPause.SetActive(false);

        Time.timeScale = 1;

    }
    public void nextLevel1v1()
    {
        intLevel = PlayerPrefs.GetInt("level");
        intLevel++;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(1);


    }
    public void nextLevel1v2()
    {
        intLevel = PlayerPrefs.GetInt("level");
        intLevel++;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(2);


    }
    public void nextLevel2v2()
    {
        intLevel = PlayerPrefs.GetInt("level");
        intLevel++;
        Debug.Log(intLevel);

        PlayerPrefs.SetInt("level", intLevel);
        SceneManager.LoadScene(3);


    }
    public void nextInstruct()
    {
        panelInstruct.SetActive(false);
        Time.timeScale = 1;

    }
    public void TestOptimizePerformance()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;

    }
}
