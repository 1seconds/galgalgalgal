using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class BulletAttack : AttackAbility
{
    private ObjectPool mObjectPool;

    protected void Awake()
    {
        base.Awake();
        mObjectPool = GetComponent<ObjectPool>();
    }
    public override void Attack()
    {
        //if(IsAttack())
        {
            mObjectPool.Invoke("PopObject", 0f);
            mObjectPool.Invoke("PopObject", 0.15f);
            mObjectPool.Invoke("PopObject", 0.3f);
            Invoke("RigidbodyIskenectied", afterTime);
        }
    }
}
