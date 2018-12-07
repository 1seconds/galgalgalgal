using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public PLAYER playerState;

    public void Select()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SelectSure(playerState);
    }
}
