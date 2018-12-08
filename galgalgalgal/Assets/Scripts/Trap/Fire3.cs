using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour {

    public float fireSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
        Shot();
	}
    void Shot()
    {
        transform.Translate(Vector2.up * fireSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("DeadZone"))
            Destroy(gameObject);
    }
}
