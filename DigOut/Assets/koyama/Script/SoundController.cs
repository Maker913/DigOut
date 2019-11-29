using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    private BgmContoller bgmContoller;
    private SeContrller SeContrller;
    public enum BgmName
    {

    }
    public enum SeName
    {

    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        bgmContoller = GetComponentInChildren<BgmContoller>();
        SeContrller = GetComponentInChildren<SeContrller>();
    }
    /// <summary>
    /// BGM再生
    /// <para>SoundController.Instance.PlayBGM("AudioManager.BgmName.名前") </para>
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(BgmName name)
    {
        bgmContoller.PlayBgm((int)name);
    }
    //BGM停止
    public void StopBGM()
    {
        bgmContoller.StopBgm();
    }
    /// <summary>
    /// SE再生
    /// <para>SoundController.Instance.PlaySE("AudioManager.SeName.名前") </para>
    /// </summary>
    /// <param name="name"></param>
    public void PlaySE(SeName name)
    {
        SeContrller.PlaySE((int)name);
    }
    //SE停止
    public void StopSE()
    {
        SeContrller.StopSE();
    }
}
