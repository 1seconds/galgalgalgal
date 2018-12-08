using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name.Contains("Player"))
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DoneGame();

    }
    

}
