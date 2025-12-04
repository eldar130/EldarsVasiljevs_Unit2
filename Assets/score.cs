using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score instance;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    private int scoreNum;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentScore.text = scoreNum.ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestScore();
    }

    void UpdateBestScore()
    {
        if (scoreNum > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", scoreNum);
            bestScore.text = scoreNum.ToString();
        }
    }

    // Updated to accept amount
    public void UpdateScore(int amount)
    {
        scoreNum += amount; // Add points
        currentScore.text = scoreNum.ToString();
        UpdateBestScore();
    }
}
