using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDone : MonoBehaviour
{
    static public bool isClear = false;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name.Contains("Player"))
        {
            isClear = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DoneGame();
        }


    }

    private void OnEnable()
    {
        isClear = false;
    }


}
