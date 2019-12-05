using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteDot : MonoBehaviour
{

    [SerializeField]
    private RenderTexture _target;
    Texture2D newTexture;
    Material material;
    Color[] Color;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

        material = GetComponent<Renderer>().material;

        newTexture = new Texture2D(_target.width, _target.height, TextureFormat.ARGB32, false, false);

        Color = GetPixels();
        newTexture.SetPixels(Color);
        newTexture.Apply();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1f / 6f)
        {
            newTexture = new Texture2D(_target.width, _target.height, TextureFormat.ARGB32, false, false);

            Color = GetPixels();
            newTexture.SetPixels(Color);
            newTexture.Apply();
            time = 0;
        }



        material.SetTexture("_MainTex",newTexture);

    }


    private Color[] GetPixels()
    {
        // アクティブなレンダーテクスチャをキャッシュしておく
        var currentRT = RenderTexture.active;

        // アクティブなレンダーテクスチャを一時的にTargetに変更する
        RenderTexture.active = _target;

        // Texture2D.ReadPixels()によりアクティブなレンダーテクスチャのピクセル情報をテクスチャに格納する
        var texture = new Texture2D(_target.width, _target.height);
        texture.ReadPixels(new Rect(0, 0, _target.width, _target.height), 0, 0);
        texture.Apply();

        // ピクセル情報を取得する
        var colors = texture.GetPixels();

        // アクティブなレンダーテクスチャを元に戻す
        RenderTexture.active = currentRT;

        return colors;
    }

}
