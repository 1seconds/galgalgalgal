using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Path))]
[RequireComponent(typeof(SpriteRenderer))]
public class Monster : MonoBehaviour {


    protected Path path;
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected float seachRange = 1;
    [SerializeField]
    public bool bleft = true;

    [SerializeField]
    protected Vector2 viewDistance;
    [SerializeField]

    public bool bTrace=false;
	protected void Awake()
	{
        path = GetComponent<Path>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
#if UNITY_EDITOR
	protected void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.back, seachRange);

        UnityEditor.Handles.color = Color.cyan;
        if (bleft) UnityEditor.Handles.DrawLine(transform.position, transform.position + new Vector3(-viewDistance.x, viewDistance.y, 0));
        else UnityEditor.Handles.DrawLine(transform.position, transform.position + new Vector3(viewDistance.x,viewDistance.y,0));
        //Vector3 leftBoundary = DirFromAngle(-viewAngle / 2);
        //Vector3 rightBoundary = DirFromAngle(viewAngle / 2);
        //UnityEditor.Handles.DrawLine(transform.position, transform.position + leftBoundary * viewDistance);
        //UnityEditor.Handles.DrawLine(transform.position, transform.position + rightBoundary * viewDistance);

    }
#endif
    //protected Vector3 DirFromAngle(float angleInDegrees)
    //{
    //    ////탱크의 좌우 회전값 갱신
    //    //if (bleft) angleInDegrees += transform.eulerAngles.y - 90+angle;
    //    //else angleInDegrees += transform.eulerAngles.y + 90-angle;
    //    ////경계 벡터값 반환
    //    //return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    //}
}
