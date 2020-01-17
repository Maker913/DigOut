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
        Order = 0,//街
        Stage,//マップ
        Stage_1819,//ボス
    }
    public enum SeName
    {
        Attack = 0,//攻撃
        Damage,//ダメージ
        Dig,//掘る
        Get,//アイテム獲得
        Jump,//ジャンプ
        Open,//箱空ける
        Option_Close,//オプション閉じる
        Option_Open,//オプション開く
        Walk,//歩き
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
    /// <para>SoundController.Instance.PlayBGM(AudioManager.BgmName.名前) </para>
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
    /// <para>SoundController.Instance.PlaySE(AudioManager.SeName.名前) </para>
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
