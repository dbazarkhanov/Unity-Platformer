using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public void MenuGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMusic()
    {
        VideoManager.instance.ChangeVideoVolume(0.1f);
    }

    public void StopVideo()
    {
        VideoManager.instance.StopVideo();
    }
}
