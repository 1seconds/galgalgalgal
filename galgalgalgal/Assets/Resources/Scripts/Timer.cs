using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int currentTime = 0;
    private int currentMinute = 0;
    private int currentSecond = 0;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = "00 분 00 초";
        StartCoroutine(CountingStart());
    }

    IEnumerator CountingStart()
    {

        yield return new WaitForSeconds(1f);

        currentTime += 1;

        currentMinute = currentTime / 60;
        currentSecond = currentTime % 60;

        if(currentMinute < 10)
        {
            gameObject.GetComponent<Text>().text = "0";
            gameObject.GetComponent<Text>().text += currentMinute;
        }
        else
            gameObject.GetComponent<Text>().text += currentMinute;

        gameObject.GetComponent<Text>().text += " 분 ";

        if (currentSecond < 10)
        {
            gameObject.GetComponent<Text>().text += "0";
            gameObject.GetComponent<Text>().text += currentSecond;
        }
        else
            gameObject.GetComponent<Text>().text += currentSecond;

        gameObject.GetComponent<Text>().text += " 초";


        StartCoroutine(CountingStart());
    }
}
