using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    public GameObject user_hardCore;
    public GameObject user_newby;
    public GameObject user_rich;
    public GameObject gm;

    private void Start()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.READY;
        GameObject.FindWithTag("GameManager").GetComponent<UIManager>().ActiveCanvas(GameObject.FindWithTag("GameManager").GetComponent<UIManager>().readyCanvas);
    }

    //게임시작
    public void SelectSure(PLAYER playerState)
    {
        switch(playerState)
        {
            case PLAYER.HARDCOREUSER:
                user_rich.SetActive(false);
                user_newby.SetActive(false);
                user_hardCore.SetActive(true);
                break;
            case PLAYER.NEWBYUSER:
                user_rich.SetActive(false);
                user_hardCore.SetActive(false);
                user_newby.SetActive(true);
                break;
            case PLAYER.RICHUSER:
                user_newby.SetActive(false);
                user_hardCore.SetActive(false);
                user_rich.SetActive(true);
                break;
            case PLAYER.GM:
                gm.SetActive(true);
                break;
        }

        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        GameObject.FindWithTag("GameManager").GetComponent<UIManager>().ActiveCanvas(GameObject.FindWithTag("GameManager").GetComponent<UIManager>().playingCanvas);
    }
}
