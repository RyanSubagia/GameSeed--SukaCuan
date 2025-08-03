using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip buttonClickSound;
    public AudioClip pickupSound;
    public AudioClip deliverySuccessSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayButtonClickSound()
    {
        sfxSource.PlayOneShot(buttonClickSound);
    }

    public void PlayPickupSound()
    {
        sfxSource.PlayOneShot(pickupSound,2f);
    }

    public void PlayDeliverySuccessSound()
    {
        sfxSource.PlayOneShot(deliverySuccessSound);
    }
}