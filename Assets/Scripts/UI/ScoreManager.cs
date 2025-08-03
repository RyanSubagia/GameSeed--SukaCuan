using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Skor bertambah! Skor sekarang: " + score);
    }
    public int GetFinalScore()
    {
        return score;
    }
}