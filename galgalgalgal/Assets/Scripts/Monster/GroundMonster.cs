using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Run))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundMonster : Monster
{
    public MOSTERS monsterType;
    [Range(0,10)]
    public float speed;
    private Run mRun;
    private Rigidbody2D mRigidbody2D=null;
    private float mInterval=0.1f;
    private AttackAbility attackAbility;
    private Vector3 localscale;
    protected void Awake()
    {
        base.Awake();
        path.speed = speed;
        mRun = GetComponent<Run>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
        attackAbility = GetComponent<AttackAbility>();
        localscale = transform.localScale;
    }
	private void OnEnable()
	{
        transform.localScale = localscale;
	}
	void FixedUpdate()
    {
        if (!bTrace)
        {

            RaycastHit2D[] hits; 
            if(bleft) hits = Physics2D.RaycastAll(transform.position, new Vector2(-viewDistance.x,viewDistance.y));
            else hits = Physics2D.RaycastAll(transform.position, viewDistance);

            foreach(RaycastHit2D ray in hits)
            {
                if(ray.transform.gameObject.tag=="Player"
                   &&(viewDistance.x!=0 && Mathf.Abs(ray.distance)<= Mathf.Abs((viewDistance.x))
                      ||(viewDistance.y!=0 && Mathf.Abs(ray.distance) <= Mathf.Abs(viewDistance.y))))
                {
                    bTrace = true;
                    attackAbility.IsAttack();
                }
            }
        }
        else
        {
            bTrace = false;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), seachRange);
            for (int i = 0; i < hitColliders.Length; i++)
            {
               
                if (hitColliders[i].tag == "Player")
                {
                    bTrace = true;         
                }
            }
           
        }
        if (!path.enabled) path.enabled = true;
        if(mRigidbody2D.velocity.x>0)
        {
            bleft = false;
            spriteRenderer.flipX = true;
        }
        else if(mRigidbody2D.velocity.x < 0)
        {
            bleft = true;
            spriteRenderer.flipX = false;
        }
    }

	//public void OnGUI()
	//{
 //       if(GUILayout.Button("click"))
 //       {
 //           Death();
 //       }
	//}
	/// <summary>
	/// 몬스터 죽일 때 호출하면 줄어들면서 사라집니다.
	/// </summary>
	public void Death()
    {
        mRigidbody2D.bodyType = RigidbodyType2D.Static;
        foreach(MonoBehaviour obj in GetComponents<MonoBehaviour>())
            obj.enabled = false;
        StartCoroutine("contractible");
    }
    public IEnumerator contractible()
    {
        while(transform.localScale.x>0.2f)
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.SetActive(false);
    }




}
