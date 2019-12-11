using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    static public Progression progression;

    public int num = 0;
    [SerializeField]
    private string[] nextCode;
    private bool startC = false;
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
    }



    // Update is called once per frame
    void Update()
    {
        switch (num)
        {
            case 0:
                MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
                if(startC)
                {
                    StoryManager.storyManager.StoryLoad("TextFile");
                    startC = false;
                }
                break;
            case 1:
                MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
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
