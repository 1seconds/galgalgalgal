using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour {

    public bool isBounce = false;
    //위치값을 이용한 상승
    public float fireSpeed = 10f;
    void Update()
    {
        Shot();
    }
    void Shot()
    {
        transform.Translate(Vector2.up * fireSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //입사각
        if(col.gameObject.tag == "Wall" || col.gameObject.tag.Contains("Ball"))
        {
            if (transform.rotation.z > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, (180 - transform.eulerAngles.z));
            }
            else if (transform.rotation.z < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, (180 + transform.eulerAngles.z));
            }

        }


    }
}
