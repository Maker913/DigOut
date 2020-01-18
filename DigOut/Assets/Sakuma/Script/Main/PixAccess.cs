using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PixAccess : MonoBehaviour {
    Texture2D drawTexture;
    Color[] buffer;
    public
    Vector2 bob;
    void Start() {
        //Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        //Color[] pixels = mainTexture.GetPixels();

        //buffer = new Color[pixels.Length];
        //pixels.CopyTo(buffer, 0);

        //// 画面上半分を塗りつぶす
        //for (int x = 0; x < mainTexture.width; x++) {
        //    for (int y = 0; y < mainTexture.height; y++) {
        //        if (y < mainTexture.height / 2) {
        //            buffer.SetValue(Color.black, x + 256 * y);
        //        }
        //    }
        //}

        //drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        //drawTexture.filterMode = FilterMode.Point;
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
    }

    public void Draw(Vector2 p) {
        for (int x = 0; x < 256; x++) {
            for (int y = 0; y < 256; y++) {
                if (Vector2.Distance(p, new Vector2(x*(bob.x/bob.y), y))< 25) {
                    buffer.SetValue(new Color (0,0,0,0), x + 256 * y);
                }
            }
        }
                    drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        Debug.Log("123");
    }


}