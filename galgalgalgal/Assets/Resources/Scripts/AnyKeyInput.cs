using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnyKeyInput : MonoBehaviour
{
    private float time_;
    public GameObject panel;
    private bool isTrigger = false;
    private void Update()
    {
        if (Input.anyKeyDown && !isTrigger)
            StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn()
    {
        isTrigger = true;

        time_ = 0;
        while (true)
        {
            time_ += (Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
            panel.GetComponent<Image>().color = Color.Lerp(new Color(0, 0, 0,0 ), new Color(0, 0, 0, 1), time_);
            if (time_ > 1f)
                break;
        }
        SceneManager.LoadScene("InGame");
    }
}
