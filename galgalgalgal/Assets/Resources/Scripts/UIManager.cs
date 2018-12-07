using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject settingUI;
    public GameObject readyCanvas;
    public GameObject playingCanvas;
    public GameObject doneCanvas;

    public GameObject inventoryImg;
    public GameObject inventorySet;
    private bool isInventoryActive = false;

    public void SettingActiveOn()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.STOP;
        Time.timeScale = 0.0f;
        settingUI.SetActive(true);
    }

    public void SettingActiveOff()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        Time.timeScale = 1.0f;
        settingUI.SetActive(false);
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
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.STOP;
        Time.timeScale = 0.0f;
        isInventoryActive = true;
        inventorySet.SetActive(true);
    }
    private void InventoryActiveOff()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentState = GAMESTATE.PLAYING;
        Time.timeScale = 0.0f;
        isInventoryActive = false;
        inventorySet.SetActive(false);
    }
}
