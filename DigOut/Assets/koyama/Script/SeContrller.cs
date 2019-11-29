using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeContrller : SoundModel
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //再生
    public void PlaySE(int number)
    {
        audioSource.PlayOneShot(audioClips[number]);
    }
    //停止
    public void StopSE()
    {
        audioSource.Stop();
    }
}
