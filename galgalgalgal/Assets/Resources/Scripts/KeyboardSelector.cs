using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSelector : MonoBehaviour
{
    public GameObject[] characterSet;
    public GameObject[] characterBollon;
    private GameObject currentSelectorObj;
    public int currentIndex = 0;
    public GameObject pointerObj;
    private float time_;
    private bool isTrigger = false;

    private void Start()
    {
        currentSelectorObj = characterSet[0];
        pointerObj.transform.position = characterSet[0].transform.position - new Vector3(0, 240, 0);
        for (int i = 0; i < characterBollon.Length; i++)
            characterBollon[i].SetActive(false);

        StartCoroutine(StartCor());
        StartCoroutine(MovePointer());
    }

    IEnumerator StartCor()
    {
        yield return new WaitForSeconds(0.5f);
        characterBollon[0].SetActive(true);
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
            for (int i = 0; i < characterBollon.Length; i++)
                characterBollon[i].SetActive(false);
            characterBollon[currentIndex].SetActive(true);
            pointerObj.transform.position = currentSelectorObj.transform.position - new Vector3(0, 240, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentIndex <= 0)
                currentIndex = 3;
            else
                currentIndex -= 1;

            currentSelectorObj = characterSet[currentIndex];
            for (int i = 0; i < characterBollon.Length; i++)
                characterBollon[i].SetActive(false);
            characterBollon[currentIndex].SetActive(true);
            pointerObj.transform.position = currentSelectorObj.transform.position - new Vector3(0, 240, 0);
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
            time_ += Time.deltaTime * 1.5f ;
            yield return new WaitForEndOfFrame();
            currentSelectorObj.transform.localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1.3f, 1.3f, 1.3f), time_);
            if (time_ > 1.0f)
                break;
        }
        time_ = 0;
        while (true)
        {
            time_ += Time.deltaTime * 1.5f;
            yield return new WaitForEndOfFrame();
            currentSelectorObj.transform.localScale = Vector3.Lerp(new Vector3(1.3f,1.3f,1.3f),new Vector3(1f, 1f, 1f), time_);
            if (time_ > 1.0f)
                break;
        }
        StartCoroutine(MovePointer());
    }
}
