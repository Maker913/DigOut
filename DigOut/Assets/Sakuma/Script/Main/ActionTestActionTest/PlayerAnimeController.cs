using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimeController : MonoBehaviour
{
    public enum AnimeMode
    {
        Idole,
        LWork,
        RWork,
        Fall

    }


    public AnimeMode animeMode;
    AnimeMode animeModeDil;
    float spead=0;


    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animeMode = AnimeMode.Idole;
        animeModeDil = animeMode;
    }

    // Update is called once per frame
    void Update()
    {

        switch (animeMode)
        {
            case AnimeMode.Idole:
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 180, ref spead, 0.1f), 0);
                break;
            case AnimeMode.LWork:
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 270, ref spead, 0.1f), 0);
                break;
            case AnimeMode.RWork:
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 90, ref spead, 0.1f), 0);
                break;
            case AnimeMode.Fall:
                break;
        }



        //切り替わった瞬間のみ呼び出し


        if(animeModeDil!= animeMode)
        {
            switch (animeMode)
            {
                case AnimeMode.Idole:
                    AnimeChange("Idole");
                    break;
                case AnimeMode.LWork:
                    AnimeChange("Work");
                    break;
                case AnimeMode.RWork:
                    AnimeChange("Work");
                    break;
                case AnimeMode.Fall:
                    AnimeChange("Jump");
                    break;
            }
        }

        animeModeDil = animeMode;

    }


    void AnimeChange(string animeName)
    {
<<<<<<< HEAD
        Debug.Log("変えます");
=======
        //Debug.Log("変えます");
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
        animator.SetBool("Idole", animeName == "Idole");
        animator.SetBool("Work", animeName == "Work");
        animator.SetBool("Jump", animeName == "Jump");
    }

}
