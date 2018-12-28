using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemManager : MonoBehaviour
{
    public GameObject camera_;
    private float time_;
    public GameObject moojuckImg;

    public void UseItem(int index)
    {
        switch(index)
        {
            case 0:
                StartCoroutine(CameraUpsideDown());
                break;
            case 1:
                GameManager.changeWaveTime += 2;
                break;
            case 2:
                StartCoroutine(MooJuck());
                break;
            case 3:
                StartCoroutine(SpeedUp());
                break;
            case 4:
                StartCoroutine(CameraBreak());
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
            if (time_ > 2)
                break;
        }
        camera_.GetComponent<Camera>().orthographicSize = 5;
    }

    IEnumerator MooJuck()
    {
        moojuckImg.SetActive(true);
        PlayerManager.isMooJuck = true;
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (time_ > 5)
                break;
        }
        PlayerManager.isMooJuck = false;
        moojuckImg.SetActive(false);
    }

    IEnumerator SpeedUp()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerManager>().moveSpeed += 5;
        GameObject.FindWithTag("Player").GetComponent<PlayerManager>().maxSpeed += 2;
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (time_ > 5)
                break;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerManager>().moveSpeed -= 5;
        GameObject.FindWithTag("Player").GetComponent<PlayerManager>().maxSpeed -= 2;
    }

    IEnumerator CameraBreak()
    {
        camera_.GetComponent<FollowCam>().enabled = false;
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (time_ > 5)
                break;
        }
        camera_.GetComponent<FollowCam>().enabled = true;
    }
}
