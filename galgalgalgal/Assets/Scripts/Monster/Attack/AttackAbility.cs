using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class AttackAbility : MonoBehaviour {

    public float delayTime;
    private float mTimeScale;
    public bool bFire;
    public float beforeTime;
    public float afterTime;
    [SerializeField]
    protected Rigidbody2D rigidbody2D;
    protected void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void OnEnable()
	{
        StartCoroutine("TimeCheck");

	}
	public void OnDisable()
	{
        StopCoroutine("TimeCheck");
	}

    private IEnumerator TimeCheck()
    {
        
        while (true)
        {
            if(!bFire)mTimeScale += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    public void IsAttack()
    {
        if(!bFire&&delayTime<=mTimeScale)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            mTimeScale = 0f;
            bFire = true;
            Invoke("Attack", beforeTime);
        }
    }
	public abstract void Attack();
    public void RigidbodyIskenectied()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        bFire = false;
    }
}
