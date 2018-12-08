using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GAMESTATE currentState;
    private UIManager uiManager;

    public void Start()
    {
        uiManager = gameObject.GetComponent<UIManager>();
        ReadyGame();
    }

    //게임준비
    public void ReadyGame()
    {
        currentState = GAMESTATE.READY;
        uiManager.ActiveCanvas(uiManager.readyCanvas);
    }

    //게임시작
    public void SelectSure(PLAYER playerState)
    {
        switch (playerState)
        {
            case PLAYER.HARDCOREUSER:
                uiManager.user_rich.SetActive(false);
                uiManager.user_newby.SetActive(false);
                uiManager.user_hardCore.SetActive(true);
                break;
            case PLAYER.NEWBYUSER:
                uiManager.user_rich.SetActive(false);
                uiManager.user_hardCore.SetActive(false);
                uiManager.user_newby.SetActive(true);
                break;
            case PLAYER.RICHUSER:
                uiManager.user_newby.SetActive(false);
                uiManager.user_hardCore.SetActive(false);
                uiManager.user_rich.SetActive(true);
                break;
            case PLAYER.GM:
                uiManager.gm.SetActive(true);
                break;
        }

        currentState = GAMESTATE.PLAYING;
        gameObject.GetComponent<UIManager>().ActiveCanvas(gameObject.GetComponent<UIManager>().playingCanvas);
    }

    //게임끝
    public void DoneGame()
    {
        currentState = GAMESTATE.DONE;
        gameObject.GetComponent<UIManager>().ActiveCanvas(gameObject.GetComponent<UIManager>().doneCanvas);
    }
}
