using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip coinSound;
    public AudioClip gameOverSound;
    public AudioClip flapSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
    }

    public void PlayFlap()
    {
        audioSource.PlayOneShot(flapSound);
    }
}
