using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextAttack : AttackAbility {
    public GameObject speechBubble;
    protected void Awake()
    {
        base.Awake();
    }
    public override void Attack()
    {
        //if(IsAttack())
        {
            speechBubble.SetActive(true);
            Invoke("RigidbodyIskenectied", afterTime);
            Invoke("SetAtctiveFasle", afterTime);
        }
    }
    private void SetAtctiveFasle()
    {
        speechBubble.SetActive(false);

    }
}
