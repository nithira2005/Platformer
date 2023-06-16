
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance { get; private set; }
    private AudioSource source;
    private AudioSource musicSource;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        //keep this object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    public void ChangeSoundVolume(float _change)
    {
        float baseVolume = 1;

        float currentVolume = PlayerPrefs.GetFloat("soundVolume");
        currentVolume += _change;
//max vol reach check
        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        //final volume
        float finalVolume = currentVolume *= baseVolume;
        source.volume = finalVolume;

        PlayerPrefs.SetFloat("soundVolume", currentVolume); 
    }

    public void ChangeMusicVolume(float _change)
    {
        float baseVolume = 0.3f;
        float currentVolume = PlayerPrefs.GetFloat("musicVolume");
        currentVolume += _change;

        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;
        //final vol
        float finalVolume = currentVolume *= baseVolume;
        musicSource.volume = finalVolume;
        

        PlayerPrefs.SetFloat("musicVolume", currentVolume);
    }
}
