using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour {
    //힘을 이용한 상승
    Rigidbody2D rigid;
    public float FirePower = 10f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
        Shot();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
    void Shot()
    {
        rigid.AddForce(Vector2.up * FirePower, ForceMode2D.Impulse);
    }
}
