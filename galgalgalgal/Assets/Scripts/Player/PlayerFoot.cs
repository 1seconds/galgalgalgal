using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Tile") || obj.CompareTag("Wall"))
        {
            PlayerManager.isJumpAble = false;
        }
    }

    public void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.CompareTag("Ground"))
        {
            PlayerManager.isGrounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Tile") || obj.CompareTag("Wall"))
        {
            PlayerManager.isJumpAble = true;
        }
        else if (obj.CompareTag("Ground"))
        {
            PlayerManager.isGrounded = false;
        }
    }
}
