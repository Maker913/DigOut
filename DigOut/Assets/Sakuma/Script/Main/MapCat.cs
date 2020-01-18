using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCat : MonoBehaviour
{

    [SerializeField]
    PixAccess pixAccess;
    [SerializeField]
    LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position,new Vector3 (0,0,-1));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 5, false);
        if (Physics.Raycast(ray, out hit, 100.0f, layerMask)) {
            pixAccess.Draw(hit.textureCoord2 * 256);
            Debug.Log(hit.textureCoord * 256);
        }

    }
}
