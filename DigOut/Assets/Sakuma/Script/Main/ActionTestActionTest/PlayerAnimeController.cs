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
        Fall,
        LAtk,
        RAtk,
        UAtk,
        DAtk,
        LTh,
        RTh

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
        if(MainStateInstance .mainStateInstance .mainState .gameMode ==MainStateInstance .GameMode.Play)
        {
            animator.SetFloat("Spead", 1);
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
                case AnimeMode.LAtk:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 270, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.RAtk:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 90, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.UAtk:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 180, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.DAtk:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 180, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.LTh:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 270, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.RTh:
                    transform.eulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.eulerAngles.y, 90, ref spead, 0.1f), 0);
                    break;
                case AnimeMode.Fall:
                    break;
            }



            //切り替わった瞬間のみ呼び出し


            if (animeModeDil != animeMode)
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
                    case AnimeMode.LAtk:
                        AnimeChange("Atk");
                        break;
                    case AnimeMode.RAtk:
                        AnimeChange("Atk");
                        break;
                    case AnimeMode.Fall:
                        AnimeChange("Jump");
                        break;
                    case AnimeMode.DAtk:
                        AnimeChange("DAtk");
                        break;
                    case AnimeMode.UAtk :
                        AnimeChange("UAtk");
                        break;
                    case AnimeMode.LTh :
                        AnimeChange("Th");
                        break;
                    case AnimeMode.RTh :
                        AnimeChange("Th");
                        break;
                }
            }

            animeModeDil = animeMode;
        }
        else
        {
            animator.SetFloat("Spead", 0);
        }






    }


    void AnimeChange(string animeName)
    {
        //Debug.Log("変えます");
        animator.SetBool("Idole", animeName == "Idole");
        animator.SetBool("Work", animeName == "Work");
        animator.SetBool("Jump", animeName == "Jump");
        animator.SetBool("Atk", animeName == "Atk");
        animator.SetBool("AtkU", animeName == "UAtk");
        animator.SetBool("AtkD", animeName == "DAtk");
        animator.SetBool("Th", animeName == "Th");
    }

}
