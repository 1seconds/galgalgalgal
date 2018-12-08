using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour {

    public float fireSpeed = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
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
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);
    }
}
