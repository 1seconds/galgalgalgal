using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public PLAYER playerState;

    public void Select()
    {
        StartCoroutine(Twinkle());
    }

    IEnumerator Twinkle()
    {
        while(true)
        {

        }
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SelectSure(playerState);
    }
}
