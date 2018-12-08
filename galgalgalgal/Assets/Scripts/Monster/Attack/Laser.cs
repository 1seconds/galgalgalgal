using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Laser : MonoBehaviour {

    public Sprite warring;
    public Sprite laser;
    public float time;
    SpriteRenderer spriteRenderer;
    public float animationTime;
	public void Awake()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	private void OnEnable()
	{
        spriteRenderer.size = new Vector2( spriteRenderer.size.x,0.1f);
        laser = warring;
        spriteRenderer.color = Color.red;
        Invoke("ChangeSprite", time);
	}
    private void ChangeSprite()
    {
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = laser;
        StartCoroutine("Warring");
    }
	public IEnumerator Warring()
    {
        float timeScale=0;
        while(animationTime<=timeScale)
        {
            timeScale += Time.deltaTime;
            spriteRenderer.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y+ 0.1f);


            yield return new WaitForSeconds(0.2f);
        }
        this.gameObject.SetActive(false);

    }
}
