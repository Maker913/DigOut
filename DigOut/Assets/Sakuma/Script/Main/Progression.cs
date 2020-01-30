using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    static public Progression progression;

    public int num = 0;
    [SerializeField]
    public string[] nextCode;
    public bool startC = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(progression == null)
        {
            startC = true;
            num = 0;
            progression = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(this);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                
                if(startC)
                {
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
                    StoryManager.storyManager.StoryLoad("StartStory");
                    startC = false;
                }
                break;
            case 1:
                if (startC)
                {
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
                    startC = false;
                }
                
                break;
            case 3:
                if (startC)
                {
                    //Scene.sceneManagerPr.SceneLoad("Title");
                    MainStateInstance.mainStateInstance.Pow = 2;
                    startC = false;
                }
                
                break;
            case 5:
                if (startC)
                {
                    Scene.sceneManagerPr.SceneLoad("Title");
                    startC = false;
                }

                break;
        }
    }

    public void progressionSet(string code)
    {
        if(nextCode[num] == code)
        {
            num++;
            startC = true;
        }
    }




}
