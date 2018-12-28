using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    static public bool isSavedOn = false;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            isSavedOn = true;
            gameObject.GetComponent<Animator>().SetBool("IsActive", true);
            PlayerPrefs.SetFloat("SavedXPos", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("SavedYPos", gameObject.transform.position.y);
        }
    }
}
