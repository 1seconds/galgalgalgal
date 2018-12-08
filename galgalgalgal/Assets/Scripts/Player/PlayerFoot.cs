using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tile" || col.gameObject.tag == "Wall")
        {
            gameObject.transform.parent.GetComponent<PlayerMove>().isJump = false;
        }
    }
}
