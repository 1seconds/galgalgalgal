using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour {

    float _shakeTime = 2f;
    float _resetTime = 5f;
    float _fallingSpeed = 5f;
    Vector2 _resetPos;
	// Use this for initialization
	void Start ()
    {
        _resetPos = transform.position;   	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Shake());
        }
    }
    /*
    IEnumerator Falling()
    {
        StopCoroutine(Shake());
        while (transform.position.y < -10f)
            Debug.Log("Sd");
            transform.Translate(Vector2.down * _fallingSpeed);
        yield return new WaitForSeconds(_resetTime);
        transform.position = _resetPos;
    }
    */
    IEnumerator Shake()
    {
        Vector2 shakePos;
        int shakeCount = 0;
        float randPosX;
        float randPosY;
        while (shakeCount < 10)
        {
            randPosX = _resetPos.x + Random.Range(-0.1f, 0.1f);
            randPosY = _resetPos.y + Random.Range(-0.1f, 0.1f);
            shakePos = new Vector2(randPosX, randPosY);
            transform.position = shakePos;
            yield return new WaitForSeconds(0.1f);
            shakeCount++;
        }
    }
}
