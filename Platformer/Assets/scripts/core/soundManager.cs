using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        //keep this object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //assign initial volumes
            ChangeMusicVolume(0);
            ChangeSoundVolume(0);
        }
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }
    //sound vol
    public void ChangeSoundVolume(float _change)
    {
        changeSourceVolume(1, "soundVolume", _change, soundSource);
    }
    //music vol
    public void ChangeMusicVolume(float _change)
    {
        changeSourceVolume(0.3f, "musicVolume", _change, musicSource);

    }
    private void changeSourceVolume(float baseVolume, string volumeName,float change,AudioSource source)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        //max vol check
        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        //final vol
        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        //save player prefs
        PlayerPrefs.SetFloat(volumeName, currentVolume); 
    }
   
}
