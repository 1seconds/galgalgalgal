using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour {

    public float fireSpeed = 10f;
    private float time_ = 0;
	// Update is called once per frame
	void Update ()
    {
        time_ += Time.deltaTime;
        Shot();

        if (time_ > 10f)
            Destroy(gameObject);
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
