using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmContoller : SoundModel
{
    private SoundController soundController;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBgm(int number)
    {
        //再生
        if(0>number||audioClips.Count <= number)
        {
            return;
        }
        //同じときは変更を加えない
        if(audioSource.clip == audioClips[number])
        {
            return;
        }
        audioSource.Stop();
        audioSource.clip = audioClips[number];
        audioSource.Play();
    }
    //停止
    public void StopBgm()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }

}
