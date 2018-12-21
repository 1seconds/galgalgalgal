using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvBelt : MonoBehaviour
{
    public bool isRightPush;
    static public bool isInsideRight = false;
    static public bool isInsideLeft = false;
    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            //오른쪽으로 밀기
            if(isRightPush)
            {
                isInsideRight = true;
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(40f, 0, 0));
            }
            //왼쪽으로 밀기
            else
            {
                isInsideLeft = true;
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(-40f, 0, 0));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            if (isRightPush)
            {
                isInsideRight = false;
            }
            //왼쪽으로 밀기
            else
            {
                isInsideLeft = false;
            }
        }
    }
}
