using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D obj)
    {
        if (gameObject.GetComponentInParent<PlayerSet>().currentPlayerState.Equals(PLAYER.RICHUSER) && obj.CompareTag("Monster"))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (gameObject.GetComponentInParent<PlayerSet>().currentPlayerState.Equals(PLAYER.RICHUSER) && obj.CompareTag("Monster"))
        {

        }            
    }
}
