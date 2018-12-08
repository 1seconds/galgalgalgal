using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchTile : MonoBehaviour
{
    public GameObject centerObj;
    public GameObject stretchObj;

    private float time_ = 0;

    public Vector2 InitXPos;
    public Vector2 DesXPos;

    public bool check = false;

    private bool isTriggerEnter = false;

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            if (!isTriggerEnter)
                StartCoroutine(Stretch());
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            isTriggerEnter = false;
        }
    }


    IEnumerator Stretch()
    {
        isTriggerEnter = true;
        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            stretchObj.transform.position = Vector2.Lerp(stretchObj.transform.position, DesXPos, time_ * 0.25f);
            centerObj.transform.position = Vector2.Lerp(centerObj.transform.position, new Vector2(DesXPos.x - (stretchObj.transform.position.x - centerObj.transform.position.x), 0), time_ * 0.125f);
            centerObj.GetComponent<SpriteRenderer>().size = new Vector2(Mathf.Lerp(0.8f, (DesXPos.x- centerObj.transform.position.x * 0.5f),time_ * 0.25f), 0.8f);

            if (time_ > 2f)
                break;
        }

        time_ = 0;

        while (true)
        {
            time_ += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            stretchObj.transform.position = Vector2.Lerp(DesXPos, InitXPos, time_ / 2);

            if (time_ > 2f)
                break;
        }
        isTriggerEnter = false;
    }

    private void Update()
    {
        if(check)
        {
            if (!isTriggerEnter)
                StartCoroutine(Stretch());
        }

    }
}
