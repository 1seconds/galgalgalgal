using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GroundMonster))]
public class BodyAttack : AttackAbility {
    
    public float speed;
    public float rushTime;
    public GroundMonster groundMonster;

    protected void Awake()
    {
        base.Awake();
        groundMonster = GetComponent<GroundMonster>();
    }
    public override void Attack()
    {
       // if(IsAttack())
            StartCoroutine("GoTrace");
    }
    IEnumerator GoTrace()
    {
        rigidbody2D.isKinematic=true;
        float timeScale = 0;
        while(timeScale<=rushTime)
        {
            timeScale += Time.deltaTime;
            if(groundMonster.bleft)rigidbody2D.velocity = new Vector2(-speed, 0);
            else rigidbody2D.velocity = new Vector2(speed, 0);
            yield return new WaitForFixedUpdate();
        }
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        Invoke("RigidbodyIskenectied", afterTime);

    }
}
