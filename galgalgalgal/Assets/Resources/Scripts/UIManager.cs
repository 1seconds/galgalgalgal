using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Canvas
    public GameObject settingCanvas;
    public GameObject readyCanvas;
    public GameObject playingCanvas;
    public GameObject doneCanvas;

    //UI
    public GameObject user_hardCore;
    public GameObject user_newby;
    public GameObject user_rich;
    public GameObject gm;

    public GameObject inventoryImg;
    public GameObject inventorySet;
    private bool isInventoryActive = false;

    public void SettingActiveOn()
    {
        gameObject.GetComponent<GameManager>().currentState = GAMESTATE.STOP;
        Time.timeScale = 0.0f;
        settingCanvas.SetActive(true);
    }

    public void SettingActiveOff()
    {
        gameObject.GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        Time.timeScale = 1.0f;
        settingCanvas.SetActive(false);
    }

    public void ActiveCanvas(GameObject canvas)
    {
        readyCanvas.SetActive(false);
        playingCanvas.SetActive(false);
        doneCanvas.SetActive(false);

        canvas.SetActive(true);
    }

    public void InventoryItemDisplay(GameObject obj)
    {
        inventoryImg.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    }

    public void InventoryActive()
    {
        if (isInventoryActive)
            InventoryActiveOff();
        else
            InventoryActiveOn();
    }

    private void InventoryActiveOn()
    {
        gameObject.GetComponent<GameManager>().currentState = GAMESTATE.STOP;
        Time.timeScale = 0.0f;
        isInventoryActive = true;
        inventorySet.SetActive(true);
    }
    private void InventoryActiveOff()
    {
        gameObject.GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        Time.timeScale = 1.0f;
        isInventoryActive = false;
        inventorySet.SetActive(false);
    }
}
