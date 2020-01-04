using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStateInstance : MonoBehaviour
{
    public enum GameMode {
        Play,
        Pause,
        Anime,
        Title,
        Story,
        Did
    }


    public struct MainState
    {
        public GameMode gameMode;
        public bool GameModeStart;
        public int nowArea;
        public void StateSet() {
            GameModeStart=true;
            gameMode = GameMode.Title;
            nowArea = 0;
        }
    }

    [SerializeField ]
    GameMode StartMode;

    public MainState mainState;
    static public MainStateInstance mainStateInstance;
    public string stageName;

    public int Life;
    public bool toolBox;

    public float footPos;

    private void Awake() {
        if (mainStateInstance == null) {
            mainState.gameMode = StartMode;
            mainState.GameModeStart = true;
            mainStateInstance = this;
            Life = 6;
            toolBox = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() {
        switch (mainState.gameMode) {
            case GameMode.Anime:
                break;
            case GameMode.Play:
                PlayUpdate();
                break;
            case GameMode.Pause:
                break;
            case GameMode.Story:
                break;
            case GameMode.Did:
                if (Life > 0) { mainState.gameMode = GameMode.Play; }
                break;
            case GameMode.Title:
                TitleUpdate();
                break;
        }
    }

    //startをfalseにするのを忘れずに!!
    private void PlayUpdate()
    {
        if (Life <= 0)
        {
            mainState.gameMode = GameMode.Did;
            MainStateInstance.mainStateInstance.stageName = "街に戻る";
            Scene.sceneManagerPr.SceneLoad("MainAction");
        }
    }
    private void TitleUpdate() {
        if (mainState.GameModeStart)
        {
            Debug.Log("aaaa");
            mainState.GameModeStart = false;
        }
        
    }

    public void ChangeGameMode(GameMode nextGameMode){
        mainState.gameMode = nextGameMode;
        mainState.GameModeStart = true;
    } 



}
