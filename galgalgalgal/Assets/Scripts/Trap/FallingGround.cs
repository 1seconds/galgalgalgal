using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour {

    float _shakeTime = 2f;
    float _resetTime = 5f;
    float _fallingSpeed = 5f;
    Vector3 _resetPos;
	// Use this for initialization
	void Start ()
    {
        _resetPos = transform.position;   	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Falling());
        }
    }
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(_shakeTime);
        transform.Translate(Vector2.down * _fallingSpeed * Time.deltaTime);
        yield return new WaitForSeconds(_resetTime);
        transform.position = _resetPos;



    }
    void Shake()
    {
        Vector2 shakePos;

    }
}
