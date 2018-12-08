using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUp : UnityEngine.Events.UnityEvent<GameObject> { };

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    public GroundMonster groundMonster;
    private Rigidbody2D mRigidbody2D;
    public int speed;
    public BackUp onBackup = new BackUp();
	private void Awake()
	{
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mRigidbody2D.isKinematic = true;
	}
	public void OnEnable()
	{
        transform.position = groundMonster.transform.position;
        if (groundMonster.bleft) speed =Mathf.Abs(speed) * -1;
        else speed = Mathf.Abs(speed) ;
        StartCoroutine("OnMove");
	}
	public void OnDisable()
	{
        StopCoroutine("OnMove");
	}
	private IEnumerator OnMove()
	{
        while(true)
        {
            mRigidbody2D.velocity= (new Vector3(speed, 0, 0));
            yield return new WaitForFixedUpdate();
        }
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag=="Player")
        {
            onBackup.Invoke(this.gameObject);
        }
	}
}
