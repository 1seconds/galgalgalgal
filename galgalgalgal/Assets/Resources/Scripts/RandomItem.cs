using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomItem : MonoBehaviour
{
    private bool isTrigger = false;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (isTrigger)
            return;
        if (obj.CompareTag("Player"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<RandomItemManager>().UseItem(Random.Range(0, 5));
            isTrigger = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        isTrigger = false;
    }
}
