using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [Header("Звуки")]
    [SerializeField] private AudioClip collectCoinSound;
    [SerializeField] private AudioClip collectItemSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;

    [Header("Вспомогательны поля")]
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCollectCoinSound() 
    {
        _audioSource.PlayOneShot(collectCoinSound);
    }

    public void PlayCollectItemSound()
    {
        _audioSource.PlayOneShot(collectItemSound);
    }

    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(loseSound);
    }
}
