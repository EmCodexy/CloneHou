using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip menuMusic;
    public AudioClip controlsMusic;
    public AudioClip shooting;
    public AudioClip enemyshooting;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();


    }

    public void PlaySFX(AudioClip clip)
    {
       
            soundSource.PlayOneShot(clip);
    }

    public void SFXoverlap(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
