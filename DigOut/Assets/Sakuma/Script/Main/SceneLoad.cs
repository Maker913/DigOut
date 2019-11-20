using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public stageSelect stageSelect;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == 12)
        {
            stageSelect.On();


        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue ;

        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }
}
