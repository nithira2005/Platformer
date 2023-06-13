
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instance = this; 
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }

}
