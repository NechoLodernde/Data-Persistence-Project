using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ScorePicker ScorePicker;
    public TMP_InputField nameText;

    public void NewScores(string name, int score)
    {
        MenuManager.Instance.playerName = name;
        MenuManager.Instance.bestScore = score;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScorePicker.SelectProfile(MenuManager.Instance.playerName, MenuManager.Instance.bestScore);
    }

    public void StartNew()
    {
        Debug.Log("Is empty? " + nameText.text.ToString());
        if (nameText.text.ToString().Equals(""))
        {
            Debug.Log("Insert name first");
        }
        else
        {
            MenuManager.Instance.playerName = nameText.text.ToString();
            MenuManager.Instance.bestScore = 0;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        MenuManager.Instance.SaveProfile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
