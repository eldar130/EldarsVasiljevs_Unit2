using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager_script : MonoBehaviour
{
    public static game_manager_script instance;
    [SerializeField] private GameObject menuCanvas;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        menuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
