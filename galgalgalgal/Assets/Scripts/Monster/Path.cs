using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public Vector3[] nodePositions = new Vector3[1];
    public float[] waitTimes = new float[1];
    [HideInInspector]
    public float speed = 1;
    private int index = 1;
    private Rigidbody2D rigidbody2d;

	private void Awake()
	{
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	public void Start()
    {
        StartCoroutine("NodeMove");
    }

    private IEnumerator NodeMove()
    {
        while (true)
        {
            if (this.enabled&& nodePositions.Length>index)
            {
                // transform.position = Vector2.MoveTowards(transform.position, nodePositions[index], speed * Time.deltaTime);
                if(rigidbody2d.bodyType==RigidbodyType2D.Kinematic)
                rigidbody2d.velocity+=Move.GetSpeed(transform.position, nodePositions[index], rigidbody2d.velocity, 0 ,speed);
                if (Vector2.Distance(transform.position, nodePositions[index]) <= 0.1f)
                {
                    index++;
                    if (index == nodePositions.Length)
                    {
                        index = MoveIndex();
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }

    }
   

    private int MoveIndex()
    {
        return 1;
        //switch (movingPlatformType)
        //{
        //    case MovingPlatformType.ONCE:
        //        StopCoroutine("NodeMove");
        //        return 0;
        //    case MovingPlatformType.BACK_FORTH:
        //        System.Array.Reverse(nodePositions);
        //        return 1;
        //    case MovingPlatformType.LOOP:
        //        return 0;
        //    default:
        //        return -1;

        //}
    }
}



