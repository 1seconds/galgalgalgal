using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : AttackAbility
{
    public GameObject LaserObj;

    protected void Awake()
	{
        base.Awake();
        LaserObj.SetActive(false);
	}

	public override void Attack()
    {
        LaserObj.SetActive(true);
      //  Invoke("RigidbodyIskenectied", afterTime);

    }

}
