using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    public AudioClip collectCoinSound, collectItemSound, winSound, loseSound;

    public AudioSource aS;
    

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }


    public void PlayCollectCoinSound() 
    {
        aS.PlayOneShot(collectCoinSound);
    }

    public void PlayCollectItemSound()
    {
        aS.PlayOneShot(collectItemSound);
    }

    public void PlayWinSound()
    {
        aS.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        aS.PlayOneShot(loseSound);
    }

}
