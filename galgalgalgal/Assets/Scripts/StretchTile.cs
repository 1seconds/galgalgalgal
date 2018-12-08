using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchTile : MonoBehaviour
{
    public bool isRight;
    public bool isTrigger = false;

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    private void Start()
    {
        
    }

    IEnumerator Work()
    {

        yield return new WaitForEndOfFrame();
    }
}
