using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Wilberforce;

public class GameManager : MonoBehaviour
{
    public GAMESTATE currentState;
    private UIManager uiManager;

    private float time_;
    private float time_2;
    public GameObject panel;
    private bool isTrigger = false;

    public GameObject tmpEffectPrefab;
    private GameObject tmpEffectObj;

    public GameObject alphacaSet;
    public GameObject alphaca;
    public GameObject bolloon;

    public Vector3 alphacaInitVec;
    public Vector3 alphacaCenterVec;
    public Vector3 alphacaFinishVec;

    [HideInInspector] public Vector3 playerInitVec = new Vector3(-1.24f, -0.76f, 0);

    IEnumerator AlphacaGo()
    {
        yield return new WaitForSeconds(Random.Range(12,30));
        alphacaSet.SetActive(true);
        alphaca.transform.localPosition = alphacaInitVec;
        time_2 = 0;
        while (true)
        {
            alphaca.transform.localPosition = Vector3.Lerp(alphacaInitVec, alphacaCenterVec, time_2);
            yield return new WaitForEndOfFrame();
            time_2 += (Time.deltaTime);
            if (time_2 > 1f)
                break;
        }
        bolloon.SetActive(true);
        alphaca.transform.localPosition = alphacaCenterVec;
        yield return new WaitForSeconds(1f);
        bolloon.SetActive(false);
        time_2 = 0;
        while (true)
        {
            alphaca.transform.localPosition = Vector3.Lerp(alphacaCenterVec, alphacaFinishVec, time_2);
            yield return new WaitForEndOfFrame();
            time_2 += (Time.deltaTime);
            if (time_2 > 1f)
                break;
        }
        alphacaSet.SetActive(false);
        alphaca.transform.localPosition = alphacaFinishVec;
        StartCoroutine(AlphacaGo());
    }

    public void Start()
    {
        panel.SetActive(true);
        uiManager = gameObject.GetComponent<UIManager>();
        StartCoroutine(FadeOut());
        ReadyGame();

        //StartCoroutine(AlphacaGo());
    }

    //게임준비
    public void ReadyGame()
    {
        Time.timeScale = 1.0f;
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
                uiManager.user_newby.SetActive(false);
                uiManager.user_hardCore.SetActive(false);
                uiManager.user_rich.SetActive(false);
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
        SoundManager.instance_.SFXPlay(SoundManager.instance_.clips[8]);
        SoundManager.instance_.SFXPlay(SoundManager.instance_.clips[9]);
        StartCoroutine(DoneGameCor());
    }

    IEnumerator DoneGameCor()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Reset");
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
        
        //init
        for(int i =0; i< GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map.Length; i++)
            GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[i].SetActive(false);

        switch (playerState)
        {
            case PLAYER.HARDCOREUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.HARDCOREUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[0];
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[0].SetActive(true);
                GameObject.FindWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().animator[0].GetComponent<Animator>().runtimeAnimatorController;
                break;
            case PLAYER.RICHUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.RICHUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[1];
                GameObject.FindWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().animator[1].GetComponent<Animator>().runtimeAnimatorController;
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[1].SetActive(true);
                break;
            case PLAYER.NEWBYUSER:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.NEWBYUSER;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[2];
                GameObject.FindWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().animator[2].GetComponent<Animator>().runtimeAnimatorController;
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().map[2].SetActive(true);
                break;
            case PLAYER.GM:
                GameObject.FindWithTag("Player").GetComponent<PlayerSet>().currentPlayerState = PLAYER.GM;
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().spr[3];
                GameObject.FindWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = GameObject.FindWithTag("Player").GetComponent<PlayerSet>().animator[3].GetComponent<Animator>().runtimeAnimatorController;
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
        DontDestroy.instance_.Delay();
        panel.SetActive(false);
    }

    public void ChangeWave()
    {
        StartCoroutine(ChangeWaveCor());
    }

    IEnumerator ChangeWaveCor()
    {
        yield return new WaitForSeconds(5);

        if (!GameObject.FindWithTag("Player").GetComponent<PlayerManager>().currentPlayerState.Equals(PLAYERSTATEMENT.DIE))
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
        SoundManager.instance_.SFXPlay(SoundManager.instance_.clips[1]);
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
