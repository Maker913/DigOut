using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField]
    GameObject[] Item;

    [SerializeField]
    bool stay;

    [SerializeField]
    int popItem;
    [SerializeField]
    float time;

    bool flg = false;
    [SerializeField]
    int cont=3;
    int cont2 = 0;



    // Start is called before the first frame update
    void Start()
    {
        flg = false;
        
    }

    // Update is called once per frame
    void Update()
    {



        if (flg)
        {
            time += Time.deltaTime;


            if (time > 0.1f)
            {
                GameObject data = Instantiate(Item[Random.Range(0, 3)], transform.position, Quaternion.identity);
                Rigidbody2D rigidbody2D = data.GetComponent<Rigidbody2D>();
                float angle;

                    angle = 60 + ((60 / (cont - 1)) * cont2);



                Debug.Log(Mathf.Cos(angle * Mathf.PI / 180) * 3.5f * (1 + (cont / 10)));
                rigidbody2D.AddForce(new Vector3(Mathf.Cos(angle*Mathf .PI /180) * 3f*(1+(cont/10)), Mathf.Sin (angle * Mathf.PI / 180)*3f * (1 + (cont / 10)), 0),ForceMode2D.Impulse );
                time = 0;
                cont2++;


                if (cont2 >= cont)
                {
                    Destroy(transform.parent.gameObject);
                }
            }




        }
        else
        {
            if (stay)
            {
                if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
                {
                    flg = true;

                    cont2 = 0;
                    time = 0;

                }
            }
        }






    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Player")
        {
            stay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Player")
        {
            stay = false;
        }
    }

}
