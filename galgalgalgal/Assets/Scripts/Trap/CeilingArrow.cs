using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingArrow : MonoBehaviour
{
    private float time_ = 0;
    private Coroutine myCor;

    public GameObject[] arrows;

    public float localDesPosY;
    public float localInitPosY;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            if (myCor != null)
                StopCoroutine(myCor);

            myCor = StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            time_ += Time.deltaTime;
            for (int i =0; i<arrows.Length;i++)
            {
                arrows[i].transform.localPosition = Vector2.Lerp(new Vector2(arrows[i].transform.localPosition.x, localInitPosY), new Vector2(arrows[i].transform.localPosition.x, localDesPosY), time_ * time_ * time_ * time_);
            }
            yield return new WaitForEndOfFrame();
            if (time_ > 1.0f)
                break;
        }

        time_ = 0;

        while (true)
        {
            time_ += Time.deltaTime;
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].transform.localPosition = Vector2.Lerp(new Vector2(arrows[i].transform.localPosition.x, localDesPosY), new Vector2(arrows[i].transform.localPosition.x, localInitPosY), time_);
            }
            yield return new WaitForEndOfFrame();
            if (time_ > 1.0f)
                break;
        }
    }

}
