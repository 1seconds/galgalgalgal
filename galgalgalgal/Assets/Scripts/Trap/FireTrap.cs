using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {

    public GameObject fire;
    float destroyDist = -10f;
    GameObject fireBall;
    GameObject SplitBall;
    GameObject leftFire;
    GameObject rightFire;
    
    public float SplitTime = 0.5f;
    void Start ()
    {
        if (fire.name == "FireBall2")
            StartCoroutine(SplitFire());
    }
    IEnumerator FireShot()
    {
        float randomCycle;
        while (true)
        {
            randomCycle = Random.Range(0.3f, 0.6f);
            fireBall = Instantiate(fire, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomCycle);
        }
    }
    IEnumerator SplitFire()
    {
        float ShotCycle = 1f;
        float DestroyCycle = 0.5f;
        while (true)
        {
            
            //직선으로 파이어볼 생성
            SplitBall = Instantiate(fire, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SplitTime);

                //방향에 따른 파이어볼 생성
            leftFire = Instantiate(fire);

            //발사각을 계산
            leftFire.transform.position = SplitBall.transform.position;
            leftFire.transform.eulerAngles = fire.transform.eulerAngles;
            leftFire.transform.eulerAngles += new Vector3(0, 0, -30);
                //방향에 따른 파이어볼 생성
            rightFire = Instantiate(fire);

            //발사각을 계산
            rightFire.transform.position = SplitBall.transform.position;
            rightFire.transform.eulerAngles = fire.transform.eulerAngles;
            rightFire.transform.eulerAngles += new Vector3(0, 0, 30);

            yield return new WaitForSeconds(DestroyCycle);
            Destroy(fireBall);
            Destroy(leftFire);
            Destroy(rightFire);

            yield return new WaitForSeconds(ShotCycle);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (fire.name == "FireBall1")
                StartCoroutine(FireShot());
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
}
