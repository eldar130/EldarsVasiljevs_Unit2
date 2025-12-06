using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager_script : MonoBehaviour
{
    public static game_manager_script instance;

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private AudioManager audioManager;
    private static bool hasStarted = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;

        if (!hasStarted)
        {
            GameOverText.SetActive(false);// hide gameover text

            audioManager.PlayMusic(audioManager.menuBackground);//playing menu music at start of game

            menuCanvas.SetActive(true);
            Time.timeScale = 0f;
            hasStarted = true;
        }
        else
        {
            menuCanvas.SetActive(false); // hide menu after restart
        }
    }

    public void GameOver()
    {
        audioManager.PlayMusic(audioManager.menuBackground);//playing menu music at game over screen
        winCanvas.SetActive(false);
        score.scoreNum = 0;
        menuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
