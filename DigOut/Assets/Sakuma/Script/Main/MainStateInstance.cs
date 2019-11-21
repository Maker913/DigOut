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
    }


    public struct MainState
    {
        public GameMode gameMode;
        public bool GameModeStart;

        public void StateSet() {
            GameModeStart=true;
            gameMode = GameMode.Title;
        }
    }

    [SerializeField ]
    GameMode StartMode;

    public MainState mainState;
    static public MainStateInstance mainStateInstance;
    public string stageName;

    private void Awake() {
        if (mainStateInstance == null) {
            mainState.gameMode = StartMode;
            mainState.GameModeStart = true;
            mainStateInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update() {
        switch (mainState.gameMode) {
            case GameMode.Anime:
                break;
            case GameMode.Play:
                break;
            case GameMode.Pause:
                break;
            case GameMode.Title:
                TitleUpdate();
                break;
        }
    }

    //startをfalseにするのを忘れずに!!

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
