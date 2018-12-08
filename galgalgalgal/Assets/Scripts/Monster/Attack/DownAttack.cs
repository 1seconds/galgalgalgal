using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttack : AttackAbility {
    public GameObject thornObj;

    protected void Awake()
	{
        base.Awake();
        thornObj.SetActive(false);
	}
	public override void Attack()
    {
      //  if (IsAttack())
        {
            Debug.Log("Down");
            thornObj.SetActive(true);
            Invoke("RigidbodyIskenectied", afterTime);
        }

    }


}
