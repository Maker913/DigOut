using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class StoryManager : MonoBehaviour
{
    [SerializeField]
    Info info;

    [SerializeField]
    string text;

    [SerializeField]
    GameObject PlayUI;
    [SerializeField]
    GameObject StoryUI;
    [SerializeField]
    GameObject StoryText;
    [SerializeField]
    GameObject StoryBack;
    [SerializeField]
    GameObject imageListObj;
    [SerializeField]
    Image BackImage;

    [SerializeField]
    Material[] imageMat;
    [SerializeField]
    RectTransform [] imageObj;

    [SerializeField]
    Text InfoText;
    [SerializeField]
    Text storyText;
    [SerializeField]
    Text storyName;

    public string[] textMessage;
    float animeTime=0;
    bool Anime;
    bool StoryOn;
    bool Move;

    int cont;

    static public StoryManager storyManager;
    String LoadName;

    
    // Start is called before the first frame update
    void Awake()
    {
        if(storyManager==null)
        {
            storyManager = this;
            DontDestroyOnLoad(transform.parent . gameObject);
            
        }
        else
        {
            Destroy(transform.parent . gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (StoryOn)
        {
            if (Anime)
            {
                animeTime += Time.deltaTime;
                BackImage.color = new Color(0, 0, 0, animeTime);

                if(animeTime > 0.5f)
                {
                    Anime = false;
                    
                }


            }
            else
            {
                StoryText.SetActive(true);
                if (Move)
                {
                    do
                    {
                        switch (textMessage[cont])
                        {
                            case "[next]":
                                Move = false;
                                break;
                            case "[end]":
                                Anime = true;
                                animeTime = 0;
                                Move = false;
                                StoryOn = false;
                                imageListObj.SetActive(false);
                                StoryText.SetActive(false);
                                break;
                            default:

                                String data = textMessage[cont].Substring(0, 1);
                                if(data== "*")
                                {
                                    storyName.text = textMessage[cont].Substring(1, textMessage[cont].Length - 1);
                                }
                                else
                                {
                                    if(textMessage[cont].Substring(0, 6) == "image=")
                                    {
                                        //Debug.Log(textMessage[cont].Length - 1);
                                        String data2 = textMessage[cont].Substring(6, textMessage[cont].Length - 6);
                                        String[] list = data2.Split(',');
                                        imageMat[int.Parse(list[0])-1].SetInt("_Mode", int.Parse(list[1]));
                                        imageObj[int.Parse(list[0])-1].anchoredPosition  = new Vector3(400*("left"==list[2]?-1:1),0,0);
                                    }
                                    else
                                    {
                                        storyText.text = textMessage[cont];
                                    }
                                    
                                }

                                break;
                        }



                        cont++;
                    } while (Move);


                }
                else
                {
                    Move = PS4ControllerInput.pS4ControllerInput .contorollerState .singleCircle ;
                }

            }


        }
        else
        {
            if (Anime)
            {
                animeTime += Time.deltaTime;
                BackImage.color = new Color(0, 0, 0,0.5f-( animeTime ));

                if (animeTime > 0.5f)
                {
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
                    
                    if(Progression.progression.nextCode[Progression.progression.num ]== LoadName)
                    {
                        InfoText.text = "";
                    }
                    Progression.progression.progressionSet(LoadName);
                    PlayUI.SetActive(true);

                    Anime = false;
                    StoryUI.SetActive(false);
                    StoryBack.SetActive(false);
                }


            }
        }




    }




    public void StoryLoad(string name)
    {
        LoadName = name;
        PlayUI.SetActive(false);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Story;

        imageListObj.SetActive(true);
        StoryUI.SetActive(true);
        StoryText.SetActive(false);
        StoryBack.SetActive(true);
        BackImage.color = new Color(0, 0, 0, 0);

        for(int i=0;i<imageMat.Length; i++)
        {
            imageMat[i].SetInt("_Mode", 3);
        }

        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load(name, typeof(TextAsset)) as TextAsset;
        string[] separator = new string[] { "\r\n" };
        textMessage = textasset.text.Split(separator, StringSplitOptions.None);



        animeTime = 0;
        Anime = true;
        Move = true;
        StoryOn = true;
        cont = 0;
    }







}
