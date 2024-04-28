using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : PersistentSingleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; set;}

    void Start() => ChangeState(GameState.Start);

    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;

        switch (newState) {
            case GameState.Start:
            // handle starting the game.
            // initate ui, menu stuff, all that jazz
            break;
            case GameState.Game:
            break;
            case GameState.End:
            break;
        }
    }
}

[Serializable]
public enum GameState {
    Start=0,
    Game=1,
    End=2
}
