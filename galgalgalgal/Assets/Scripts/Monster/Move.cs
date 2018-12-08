using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour {

    [HideInInspector]
    public Rigidbody2D rigidbody2d=null;
	protected void Awake()
	{
        rigidbody2d = GetComponent<Rigidbody2D>();
        //rigidbody.isKinematic = true;
	}
    public static Vector2 GetSpeed(Vector3 currentPos, Vector3 targetPos, Vector2 velocity, float deceleration, float maxSpeed)
    {

        Vector3 toTarget = targetPos - currentPos;
        float dist = Vector2.Distance(currentPos, targetPos);

        //if (dist > 0)
        //{
        float speed =maxSpeed; /// //(deceleration * 0.3f);
            speed = Mathf.Min(speed, maxSpeed);
            Vector2 desiredVelocity = toTarget * speed / dist;
            return desiredVelocity - velocity;
        //}
        //return Vector2.zero;
    }
    public static Vector2 GetSpeedx(Vector3 currentPos, Vector3 targetPos, Vector2 velocity, float deceleration, float maxSpeed)
    {
        targetPos.y = 0;
        currentPos.y = 0;
        Vector3 toTarget = targetPos - currentPos;
        float dist = Vector2.Distance(currentPos, targetPos);

        if (dist > 0)
        {
        float speed = maxSpeed; /// //(deceleration * 0.3f);
        speed = Mathf.Min(speed, maxSpeed);
        Vector2 desiredVelocity = toTarget * speed / dist;
        return desiredVelocity - velocity;
        }

        return Vector2.zero;
    }
}
