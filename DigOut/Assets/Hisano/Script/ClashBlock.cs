using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClashBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if(PS4ControllerInput.pS4ControllerInput.contorollerState.downButton && PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            RaycastHit2D hit2D = Physics2D.BoxCast(transform.position, new Vector2(0.5f,1), 0, Vector2.down,2f, layerMask);
            if (hit2D == true)
            {
                if (hit2D.collider.tag == "5")
                {
                    hit2D.collider.gameObject.GetComponent<ClashEffect>().particleSystem.Play();
                    hit2D.collider.gameObject.SetActive(false);
                }
            }
            
        }

        if(PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk && PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            RaycastHit2D hit2D = Physics2D.BoxCast(transform.position, new Vector2(0.5f,1), 0, Vector2.right,2f, layerMask);
            if (hit2D == true)
            {
                if (hit2D.collider.tag == "5")
                {
                    hit2D.collider.gameObject.GetComponent<ClashEffect>().particleSystem.Play();
                    hit2D.collider.gameObject.SetActive(false);
                }
            }
        }

        if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk && PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            RaycastHit2D hit2D = Physics2D.BoxCast (transform.position,new Vector2(0.5f, 1),0, Vector2.left,2f, layerMask);
            if (hit2D == true)
            {
                if (hit2D.collider.tag == "5")
                {
                    hit2D.collider.gameObject.GetComponent<ClashEffect>().particleSystem.Play();
                    hit2D.collider.gameObject.SetActive(false);
                }
            }
        }

        Debug.DrawRay(transform.position, (Vector3)(Vector2.right * 2f));
    }
}
