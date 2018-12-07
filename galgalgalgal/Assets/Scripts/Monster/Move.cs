using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour {

    [HideInInspector]
    public Rigidbody2D rigidbody=null;
	protected void Awake()
	{
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
	}
}
