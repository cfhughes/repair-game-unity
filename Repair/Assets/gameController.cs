using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {WAITING_FOR_START, PLAYING}

public class GameController : MonoBehaviour
{

    
    GameState gameState = GameState.PLAYING;
    public EndFade endFade;

    void Start()
    {
    }

    public void EndGame()
    {
        if(gameState == GameState.PLAYING)
        {
            gameState = GameState.WAITING_FOR_START;
            endFade.enableText(true);
            endFade.setText("Game Over\nYou repaired for XX seconds");
            endFade.Fade();
        }
    }
}
