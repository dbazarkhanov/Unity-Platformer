using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        instance = this;
        soundSource = GetComponent<AudioSource>();
        if (transform.childCount > 0)
        {
            musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }

    public void ChangeSoundVolume(float _change)
    {
        float baseVolume = 1;

        float currentVolume = PlayerPrefs.GetFloat("soundVolume");
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
        soundSource.volume = finalVolume;

        PlayerPrefs.SetFloat("soundVolume", currentVolume);
    }

    public void ChangeMusicVolume(float _change)
    {
        float baseVolume = 1f;

        float currentVolume = PlayerPrefs.GetFloat("musicVolume");
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
        musicSource.volume = finalVolume;

        PlayerPrefs.SetFloat("musicVolume", currentVolume);
    }
}
