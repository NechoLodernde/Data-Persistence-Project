using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestPicker : MonoBehaviour
{
    public string bestName;
    public int bestScore;

    public TextMeshProUGUI BestScoreText;

    public void SelectProfile(string name, int score)
    {
        bestName = name;
        bestScore = score;
        BestScoreText.text = "Best Score: " + name + " : " + score;
    }
}
