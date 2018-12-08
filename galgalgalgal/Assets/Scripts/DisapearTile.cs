using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearTile : MonoBehaviour
{
    private float time_ = 0;
    private bool isTrigger = false;
    public float dissapearTime; 
    private void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }

    private void Update()
    {
        if (isTrigger)
        {
            time_ += Time.deltaTime;
            if (time_ > dissapearTime)
            {
                gameObject.SetActive(false);
            }
                

        }

    }
}
