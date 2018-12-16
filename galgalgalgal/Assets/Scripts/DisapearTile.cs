using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearTile : MonoBehaviour
{
    private float time_ = 0;
    private bool isTrigger = false;
    public float dissapearTime; 

    private void OnCollisionStay2D(Collision2D obj)
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
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

                if (time_ > dissapearTime + 5)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    time_ = 0;
                    isTrigger = false;
                }
            }
        }

    }
}
