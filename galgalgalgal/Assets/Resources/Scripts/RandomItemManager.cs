using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemManager : MonoBehaviour
{
    public GameObject camera_;
    private float time_;

    public void UseItem(int index)
    {
        switch(index)
        {
            case 0:
                StartCoroutine(CameraUpsideDown());
                break;
            case 1:
                StartCoroutine(CameraUpsideDown());
                break;
            case 2:
                StartCoroutine(CameraUpsideDown());
                break;
            case 3:
                StartCoroutine(CameraUpsideDown());
                break;

        }
    }

    IEnumerator CameraUpsideDown()
    {
        time_ = 0;
        camera_.GetComponent<Camera>().orthographicSize = -5;
        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (time_ > 5)
                break;
        }
        camera_.GetComponent<Camera>().orthographicSize = 5;

    }
}
