using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour {
    //힘을 이용한 상승
    Rigidbody2D rigid;
    public float FirePower = 15f;
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
    }
    void Shot()
    {
        rigid.AddForce(Vector2.up * FirePower, ForceMode2D.Impulse);
    }
}
