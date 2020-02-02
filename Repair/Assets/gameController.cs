using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState {WAITING_FOR_START, PLAYING, GAME_OVER}

public class GameController : MonoBehaviour
{

    
    public GameState gameState = GameState.WAITING_FOR_START;
    public EndFade endFade;
    public TextMeshPro timerText;
    public GameObject renderTexture;

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
            gameState = GameState.GAME_OVER;
            endFade.enableText(true);
            endFade.setText("Game Over\nYou repaired for "+gameTime.ToString("F2")+" seconds");
            endFade.Fade(true);
            StartCoroutine(WaitForStartAfterTenSeconds());
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            renderTexture.gameObject.SetActive(!renderTexture.gameObject.activeInHierarchy);
        }

        if(gameState == GameState.WAITING_FOR_START)
            return;
        
        gameTime += Time.deltaTime;
        timerText.text = gameTime.ToString("F2");
    }

    IEnumerator WaitForStartAfterTenSeconds()
    {
        yield return new WaitForSeconds(5);
        gameState = GameState.WAITING_FOR_START;
    }
}
