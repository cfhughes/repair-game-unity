using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState {WAITING_FOR_START, PLAYING}

public class GameController : MonoBehaviour
{

    
    public GameState gameState = GameState.WAITING_FOR_START;
    public EndFade endFade;
    public TextMeshPro timerText;

    float gameTime;

    void Start()
    {
        timerText.text = "Press to Repair";
    }

    public void StartGame()
    {
        print("Start Game");
        if(gameState == GameState.WAITING_FOR_START)
        {
            gameState = GameState.PLAYING;
            endFade.enableText(false);
            endFade.Fade(false);
            gameTime = 0;
        }
    }

    public void EndGame()
    {
        print("End Game");
        if(gameState == GameState.PLAYING)
        {
            gameState = GameState.WAITING_FOR_START;
            endFade.enableText(true);
            endFade.setText("Game Over\nYou repaired for "+gameTime.ToString("F2")+" seconds");
            endFade.Fade(true);
        }
    }

    void Update()
    {
        if(gameState == GameState.WAITING_FOR_START)
            return;
        
        gameTime += Time.deltaTime;
        timerText.text = gameTime.ToString("F2");
    }
}
