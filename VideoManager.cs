using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;
    private VideoPlayer videoSource;
    float currentVolume = 0f;

    private void Awake()
    {
        instance = this;
        videoSource = GetComponent<VideoPlayer>();
    }

    public void ChangeVideoVolume(float _change)
    {
        float baseVolume = 1;

        currentVolume += _change;

        if (currentVolume > 1)
        {
            currentVolume = 0;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 1;
        }

        float finalVolume = currentVolume * baseVolume;

        videoSource.SetDirectAudioVolume(0, finalVolume);
    }

    public void StopVideo()
    {
        if (videoSource.isPlaying)
        {
            videoSource.Stop();
        }
        else
        {
            videoSource.Play();
        }
    }
}
