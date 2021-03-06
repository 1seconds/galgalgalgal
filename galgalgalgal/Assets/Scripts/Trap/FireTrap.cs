﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {

    public GameObject fire;
    float destroyDist = -10f;
    GameObject fireBall;
    GameObject SplitBall;
    GameObject leftFire;
    GameObject rightFire;
    
    public float SplitTime = 1f;
    private void OnEnable()
    {
        if (fire.name.Contains("FireBall2"))
        {
            StartCoroutine(SplitFire());
        }
        
    }

    IEnumerator FireShot()
    {
        float randomCycle;
        while (true)
        {
            randomCycle = Random.Range(0.4f, 1f);
            fireBall = Instantiate(fire, transform.position, Quaternion.identity);
            fireBall.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(randomCycle);
        }
    }
    IEnumerator SplitFire()
    {
        float ShotCycle = 1f;
        float DestroyCycle = 0.5f;
        float randRotate;
        while (true)
        {
            //직선으로 파이어볼 생성
            SplitBall = Instantiate(fire, transform.position, Quaternion.identity);
            SplitBall.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(SplitTime);

            //방향에 따른 파이어볼 생성
            leftFire = Instantiate(fire);
            leftFire.transform.parent = gameObject.transform;
            //발사각을 계산
            randRotate = Random.Range(-30f, -1f);
            leftFire.transform.position = SplitBall.transform.position;
            leftFire.transform.eulerAngles = fire.transform.eulerAngles;
            leftFire.transform.eulerAngles += new Vector3(0, 0, randRotate);
                //방향에 따른 파이어볼 생성
            rightFire = Instantiate(fire);
            rightFire.transform.parent = gameObject.transform;
            //발사각을 계산
            randRotate = Random.Range(1f, 30f);
            rightFire.transform.position = SplitBall.transform.position;
            rightFire.transform.eulerAngles = fire.transform.eulerAngles;
            rightFire.transform.eulerAngles += new Vector3(0, 0, randRotate);

            yield return new WaitForSeconds(DestroyCycle);
            Destroy(SplitBall);
            Destroy(leftFire);
            Destroy(rightFire);

            yield return new WaitForSeconds(ShotCycle);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Player"))
        {
            if (fire.name.Contains("FireBall1"))
                StartCoroutine(FireShot());
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            StopAllCoroutines();
        }
    }
}
