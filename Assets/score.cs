using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score instance;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private GameObject winCanvas;
    AudioManager audioManager;
    public static int scoreNum;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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

        // display you win and restart or continue text
        if (scoreNum == 100)
        {
            audioManager.PlaySFX(audioManager.winSound);
            winCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        winCanvas.SetActive(false);
        game_manager_script.instance.RestartGame();
    }
}