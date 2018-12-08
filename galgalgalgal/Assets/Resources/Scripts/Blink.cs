using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private float time_;

    private void Start()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        time_ = 0;
        while (true)
        {
            time_ += (Time.deltaTime);
            yield return new WaitForEndOfFrame();
            gameObject.GetComponent<Image>().color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0.2f), time_);
            if (time_ > 1f)
                break;
        }

        time_ = 0;

        while (true)
        {
            time_ += (Time.deltaTime);
            yield return new WaitForEndOfFrame();
            gameObject.GetComponent<Image>().color = Color.Lerp(new Color(1, 1, 1, 0.2f), new Color(1, 1, 1, 1f), time_);
            if (time_ > 1f)
                break;
        }

        StartCoroutine(Work());
    }
}
