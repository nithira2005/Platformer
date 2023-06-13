
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instance = this; 
        source = GetComponent<AudioSource>();
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

}
