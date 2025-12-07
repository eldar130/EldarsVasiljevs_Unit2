using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip menuBackground;
    public AudioClip gameBackground;
    public AudioClip hitPipe;
    public AudioClip hitFloor;
    public AudioClip coinPickup;
    public AudioClip flap;
    public AudioClip trollfaceLaugh;
    public AudioClip winSound;

    //play background music
    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music && musicSource.isPlaying)
            return; // Already playing this music

        musicSource.loop = true;
        musicSource.clip = music;
        musicSource.Play();
    }
    //sound affects
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
