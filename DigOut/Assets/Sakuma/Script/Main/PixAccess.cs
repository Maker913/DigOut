using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PixAccess : MonoBehaviour {
    Texture2D drawTexture;
    //Color[] buffer;
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
        if (MainStateInstance.mainStateInstance.mapbuffer == null)
        {
            MainStateInstance.mainStateInstance.mapbuffer = new Color[pixels.Length];
            pixels.CopyTo(MainStateInstance.mainStateInstance.mapbuffer, 0);
            Debug.Log("わってい"); 
        }
        
        

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;

    }

    public void Draw(Vector2 p) {
        if (MainStateInstance.mainStateInstance.mapbuffer != null)
        {


            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    if (Vector2.Distance(p, new Vector2(x * (bob.x / bob.y), y)) < 50)
                    {
                        float alfa = Mathf.Pow(Vector2.Distance(p, new Vector2(x * (bob.x / bob.y), y)) / 40, 4);
                        if (MainStateInstance.mainStateInstance.mapbuffer[x + 256 * y].a > alfa)
                        {
                            MainStateInstance.mainStateInstance.mapbuffer.SetValue(new Color(MainStateInstance.mainStateInstance.mapbuffer[x * 256 + y].r, MainStateInstance.mainStateInstance.mapbuffer[x * 256 + y].g, MainStateInstance.mainStateInstance.mapbuffer[x * 256 + y].b, alfa), x + 256 * y);
                        }

                    }
                }
            }
        }
                    drawTexture.SetPixels(MainStateInstance.mainStateInstance.mapbuffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        Debug.Log("123");
    }


}