using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    static public int cnt = -1;

    public static DontDestroy instance_;
    private void Start()
    {
        cnt += 1;
        if (instance_ == null)
            instance_ = this;
        DontDestroyOnLoad(this);
    }

    public void Delay()
    {
        gameObject.GetComponentInChildren<Text>().text = "환생횟수 : " + cnt;
    }
}
