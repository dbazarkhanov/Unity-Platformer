using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public UnityEvent GamePaused;

    public UnityEvent GameResumed;

    private bool _isPaused = false;

    public GameObject gameOverMenuUI;

    public HealthManager playerHealth;

    private void Start()
    {
        gameOverMenuUI.SetActive(false);
 
        foreach (Transform child in pauseMenuUI.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerHealth.currentHealth == 0)
        {
            pauseMenuUI.SetActive(false);
            gameOverMenuUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePaused.Invoke();
        foreach (Transform child in pauseMenuUI.transform)
        {
            child.gameObject.SetActive(true);
        }
        _isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameResumed.Invoke();
        foreach (Transform child in pauseMenuUI.transform)
        {
            child.gameObject.SetActive(false);
        }
        _isPaused = false;
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SoundChange()
    {
        SoundManager.instance.ChangeSoundVolume(0.1f);
    }

    public void MusicChange()
    {
        SoundManager.instance.ChangeMusicVolume(0.1f);
    }
}
