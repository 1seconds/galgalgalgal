using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundMonster))]
public class LaserAttack : AttackAbility
{
    public GameObject LaserObj;
    GroundMonster groundMonster;
    protected void Awake()
	{
        base.Awake();
        LaserObj.SetActive(false);
        groundMonster = GetComponent<GroundMonster>();
	}

	public override void Attack()
    {
        //if (groundMonster.bleft) LaserObj.transform.localPosition = new Vector3(-LaserObj.transform.localPosition.x, LaserObj.transform.localPosition.y, LaserObj.transform.localPosition.z);
        //else  LaserObj.transform.localPosition = new Vector3(Mathf.Abs(LaserObj.transform.localPosition.x), LaserObj.transform.localPosition.y, LaserObj.transform.localPosition.z);

        if (!groundMonster.bleft) LaserObj.transform.localRotation = Quaternion.Euler(LaserObj.transform.localRotation.x, LaserObj.transform.localRotation.y, LaserObj.transform.localRotation.z);
        else  LaserObj.transform.localRotation =  Quaternion.Euler(LaserObj.transform.localRotation.x, 180, LaserObj.transform.localRotation.z);


        LaserObj.SetActive(true);
        Invoke("LaserFalse", afterTime);
        Invoke("RigidbodyIskenectied", afterTime);

    }
    void LaserFalse()
    {
        
        LaserObj.SetActive(false);
    }





}
