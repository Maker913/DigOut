using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == 12)
        {
            MainStateInstance.mainStateInstance.stageName = "Moc1";
            Scene.sceneManagerPr.SceneLoad("MainAction");
            
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue ;

        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }
}
