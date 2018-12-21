using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSelector : MonoBehaviour
{
    public GameObject[] characterSet;
    private GameObject currentSelectorObj;
    public int currentIndex = 0;
    public GameObject pointerObj;
    private float time_;
    private bool isTrigger = false;

    private void Start()
    {
        currentSelectorObj = characterSet[0];
        pointerObj.transform.position = characterSet[0].transform.position + new Vector3(0, 160, 0);
        StartCoroutine(MovePointer());
    }

    private void Update()
    {
        if (isTrigger)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentIndex >= 3)
                currentIndex = 0;
            else
                currentIndex += 1;

            currentSelectorObj = characterSet[currentIndex];
            pointerObj.transform.position = currentSelectorObj.transform.position + new Vector3(0, 160, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentIndex <= 0)
                currentIndex = 3;
            else
                currentIndex -= 1;

            currentSelectorObj = characterSet[currentIndex];
            pointerObj.transform.position = currentSelectorObj.transform.position + new Vector3(0, 160, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isTrigger = true;
            currentSelectorObj.GetComponent<CharacterSelector>().Select();
        }
    }

    IEnumerator MovePointer()
    {
        time_ = 0;
        while(true)
        {
            time_ += Time.deltaTime * 2;
            yield return new WaitForEndOfFrame();
            pointerObj.transform.position = Vector3.Lerp(pointerObj.transform.position, pointerObj.transform.position - new Vector3(0,1,0), time_);
            if (time_ > 1.0f)
                break;
        }
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime * 2;
            yield return new WaitForEndOfFrame();
            pointerObj.transform.position = Vector3.Lerp(pointerObj.transform.position, pointerObj.transform.position + new Vector3(0, 1, 0), time_);
            if (time_ > 1.0f)
                break;
        }
        StartCoroutine(MovePointer());
    }
}
