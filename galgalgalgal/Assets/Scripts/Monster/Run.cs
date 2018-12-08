using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Move {
    [HideInInspector]
    public float speed;
    Vector2 mMovement;
    public void LeftRun()
    {
        //mMovement = Vector2.left;
        //mMovement = mMovement.normalized * speed * Time.deltaTime;
        //base.rigidbody2d.MovePosition( new Vector2(transform.position.x,transform.position.y)+ mMovement);
        base.rigidbody2d.velocity += GetSpeedx(transform.position, Vector2.left, rigidbody2d.velocity, 1, speed);
    }
    public void RightRun()
    {
        //mMovement = Vector2.right;
        //mMovement = mMovement.normalized * speed * Time.deltaTime;
        //base.rigidbody2d.MovePosition(new Vector2(transform.position.x, transform.position.y) + mMovement);
        base.rigidbody2d.velocity += GetSpeedx(transform.position, Vector2.right, rigidbody2d.velocity, 1, speed);
    }
}
