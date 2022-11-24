using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePicker : MonoBehaviour
{
    public string bestName;
    public int bestScore;

    public TextMeshProUGUI bestScoreText;

    public void SelectProfile(string name, int score)
    {
        bestScoreText.text = "Best Score " + name + " : " + score;
    }
}
