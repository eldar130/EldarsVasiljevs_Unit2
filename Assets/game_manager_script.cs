using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager_script : MonoBehaviour
{
    public static game_manager_script instance;

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private Vector2 buttonOffset;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private AudioManager audioManager;
    private static bool hasStarted = false;
    public bool isGameActive { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;

        //as soon as game starts
        if (!hasStarted)
        {
            GameOverText.SetActive(false);// hide gameover text
            restartButton.SetActive(false);//hide restart button

            //move play button
            RectTransform playButtonRect = playButton.GetComponent<RectTransform>();
            if (playButtonRect != null)
            {
                playButtonRect.anchoredPosition = buttonOffset;
            }

            audioManager.PlayMusic(audioManager.menuBackground);//playing menu music at start of game

            menuCanvas.SetActive(true);
            Time.timeScale = 0f;
            hasStarted = true;
            isGameActive = false;
        }
        //all other times the game is played
        else
        {
            menuCanvas.SetActive(false); // hide menu after restart
            audioManager.PlayMusic(audioManager.gameBackground);//playing game music when playing the game
            isGameActive = true;
        }
    }

    public void GameOver()
    {
        playButton.SetActive(false);//hide play button
        restartButton.SetActive(true);//show restart button

        //move restart button
        RectTransform restartButtonRect = restartButton.GetComponent<RectTransform>();
        if (restartButtonRect != null)
        {
            restartButtonRect.anchoredPosition = buttonOffset;
        }
        
        GameOverText.SetActive(true);
        audioManager.PlayMusic(audioManager.menuBackground);//playing menu music at game over screen
        winCanvas.SetActive(false);
        score.scoreNum = 0;
        menuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isGameActive = false;
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        audioManager.PlayMusic(audioManager.gameBackground);
        Time.timeScale = 1f;
        isGameActive = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // If running in the Unity Editor
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // If running as a standalone build
        Application.Quit();
    #endif
    }
}
