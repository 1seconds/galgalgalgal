using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if(player.transform.position.x > -5.7f && player.transform.position.x < 170f)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
            
    }
}
