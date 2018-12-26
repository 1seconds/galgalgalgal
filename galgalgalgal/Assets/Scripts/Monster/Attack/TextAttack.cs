using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextAttack : AttackAbility
{
    public GameObject[] speechBubble;
    protected void Awake()
    {
        base.Awake();
    }
    public override void Attack()
    {
        //if(IsAttack())
        {
            speechBubble[Random.Range(0,2)].SetActive(true);
            Invoke("RigidbodyIskenectied", afterTime);
            Invoke("SetAtctiveFasle", afterTime);
        }
    }
    private void SetAtctiveFasle()
    {
        for (int i = 0; i < speechBubble.Length; i++)
            speechBubble[i].SetActive(false);
    }
}
