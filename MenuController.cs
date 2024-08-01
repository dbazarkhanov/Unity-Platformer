using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMusic()
    {
        SoundManager.instance.ChangeSoundVolume(0.1f);
    }
}
