using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{

    [SerializeField]
    bool on;
    [SerializeField]
    float time;
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    GameObject image;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    Rigidbody2D rigidbody;
    bool flg=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (flg)
            {
                time -= Time.deltaTime;
                if (time < 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                
                time -= Time.deltaTime;
                if (time < 0)
                {
                    bool next=true;
                    while(next)
                    {
                        
                         RaycastHit2D data= Physics2D.CircleCast(transform.position, 2, Vector2.up, 0, layerMask);
                        if (data == false)
                        {
                            break;
                        }
                        Debug.Log("21");
                        PointMake pointMake= data.collider.gameObject.GetComponent<PointMake>();
                        pointMake.Bom();
                    }


                    rigidbody.constraints =RigidbodyConstraints2D.FreezeAll;

                    image.SetActive(false);
                    particle.Play();
                    flg = true;
                    time = 2;
                }
            }

        }
        
    }
}
