using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestScoreText;
    public GameObject GameOverText;
    public BestPicker BestPicker;
    private string bestName;
    private string bestScore;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        string tempName = MenuManager.Instance.playerName;
        int tempScore = MenuManager.Instance.bestScore;

        MenuManager.Instance.LoadProfile();
        Debug.Log("Text for best score: " + MenuManager.Instance.bestScore);
        BestPicker.SelectProfile(MenuManager.Instance.playerName, MenuManager.Instance.bestScore);
        MenuManager.Instance.playerName = tempName;
        MenuManager.Instance.bestScore = tempScore;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        Debug.Log(MenuManager.Instance.playerName);
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        MenuManager.Instance.bestScore += point;
        ScoreText.text = $"Score : {MenuManager.Instance.playerName} : {m_Points}";
    }

    public void GameOver()
    {
        Debug.Log("Current score: " + MenuManager.Instance.bestScore);
        Debug.Log("High score: " + MenuManager.Instance.bestScore);
        if (MenuManager.Instance.bestScore >= BestPicker.bestScore)
        {
            MenuManager.Instance.SaveProfile();
            MenuManager.Instance.bestScore = 0;
            m_GameOver = true;
            GameOverText.SetActive(true);
        }
        else
        {
            MenuManager.Instance.bestScore = 0;
            m_GameOver = true;
            GameOverText.SetActive(true);
        }
    }
}
