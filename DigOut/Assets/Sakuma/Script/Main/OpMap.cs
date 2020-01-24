using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpMap : MonoBehaviour
{
    Texture2D drawTexture;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        drawTexture = new Texture2D(256, 256, TextureFormat.RGBA32, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainStateInstance.mainStateInstance.mapbuffer != null)
        {
            drawTexture.SetPixels(MainStateInstance.mainStateInstance.mapbuffer);
            drawTexture.Apply();

            var rect = new Rect(0, 0, 256, 256);
            var pivot = new Vector2(0.5f, 0.5f);
            var sprite = Sprite.Create(drawTexture, rect, pivot);

            image.sprite = sprite;
        }

    }
}
