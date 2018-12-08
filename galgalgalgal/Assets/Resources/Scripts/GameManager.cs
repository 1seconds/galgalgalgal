using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class GameManager : MonoBehaviour
{
    public GAMESTATE currentState;
    private UIManager uiManager;

    private float time_;
    public GameObject panel;
    private bool isTrigger = false;

    public GameObject tmpEffectPrefab;
    private GameObject tmpEffectObj;

    private int cnt = 0;

    public void Start()
    {
        panel.SetActive(true);
        uiManager = gameObject.GetComponent<UIManager>();
        StartCoroutine(FadeOut());
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
        ChangeWave();
        switch (playerState)
        {
            case PLAYER.HARDCOREUSER:
                uiManager.user_rich.SetActive(false);
                uiManager.user_newby.SetActive(false);
                uiManager.user_hardCore.SetActive(true);
                uiManager.gm.SetActive(false);
                break;
            case PLAYER.NEWBYUSER:
                uiManager.user_rich.SetActive(false);
                uiManager.user_hardCore.SetActive(false);
                uiManager.user_newby.SetActive(true);
                uiManager.gm.SetActive(false);
                break;
            case PLAYER.RICHUSER:
                uiManager.user_newby.SetActive(false);
                uiManager.user_hardCore.SetActive(false);
                uiManager.user_rich.SetActive(true);
                uiManager.gm.SetActive(false);
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

    IEnumerator ScreenEffect()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<Colorblind>().SetScreenEffect(false);
        yield return new WaitForSeconds(0.05f);
        GameObject.FindWithTag("MainCamera").GetComponent<Colorblind>().SetScreenEffect(true);
        yield return new WaitForSeconds(0.05f);
        GameObject.FindWithTag("MainCamera").GetComponent<Colorblind>().SetScreenEffect(false);
        yield return new WaitForSeconds(0.05f);
        GameObject.FindWithTag("MainCamera").GetComponent<Colorblind>().SetScreenEffect(true);
    }

    public void ChangePlayer(PLAYER playerState)
    {
        if (!GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState.Equals(PLAYER.NONE))
        {
            StartCoroutine(ChangeEffectCor());
            StartCoroutine(ScreenEffect());
        }
        
        switch (playerState)
        {
            case PLAYER.HARDCOREUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.HARDCOREUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[0];
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[0].SetActive(true);
                
                break;
            case PLAYER.RICHUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.RICHUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[1];
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[1].SetActive(true);
                break;
            case PLAYER.NEWBYUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.NEWBYUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[2];
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[2].SetActive(true);
                break;
            case PLAYER.GM:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.GM;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[3];
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[3].SetActive(true);
                break;
        }
        SelectSure(playerState);
    }

    IEnumerator FadeOut()
    {
        isTrigger = true;
        time_ = 0;
        while (true)
        {
            time_ += (Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
            panel.GetComponent<Image>().color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), time_);
            if (time_ > 1f)
                break;
        }
        panel.SetActive(false);
    }

    public void ChangeWave()
    {
        StartCoroutine(ChangeWaveCor());
    }

    IEnumerator ChangeWaveCor()
    {
        yield return new WaitForSeconds(5);
        RandomChange();
    }

    private void RandomChange()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                ChangePlayer(PLAYER.GM);
                break;
            case 1:
                ChangePlayer(PLAYER.HARDCOREUSER);
                break;
            case 2:
                ChangePlayer(PLAYER.NEWBYUSER);
                break;
            case 3:
                ChangePlayer(PLAYER.RICHUSER);
                break;
        }
    }

    IEnumerator ChangeEffectCor()
    {
        tmpEffectObj = Instantiate(tmpEffectPrefab);
        tmpEffectObj.transform.position = GameObject.FindWithTag("Player").transform.position;

        for (int i = 1; i < GameObject.FindWithTag("Player").GetComponent<PlayerSet>().changeEffectSpr.Length; i++)
        {
            tmpEffectObj.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().changeEffectSpr[i];
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(tmpEffectObj);
    }
}
