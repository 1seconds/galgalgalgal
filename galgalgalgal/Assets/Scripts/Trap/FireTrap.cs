using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {

    public GameObject fire;
	void Start ()
    {
        StartCoroutine(SplitFire());
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
    IEnumerator FireShot()
    {
        float DestroyCycle = 4f;
        while (true)
        {
            GameObject fireBall = Instantiate(fire, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(DestroyCycle);
            Destroy(fireBall);
        }
    }
    IEnumerator SplitFire()
    {
        float ShotCycle = 1f;
        float DestroyCycle = 10f;
        float SplitTime = 0.5f;
        while (true)
        {
            //직선으로 파이어볼 생성
            GameObject fireBall = Instantiate(fire, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SplitTime);

            //방향에 따른 파이어볼 생성
            GameObject leftFire = Instantiate(fire);

            //발사각을 계산
            leftFire.transform.position = fireBall.transform.position;
            leftFire.transform.eulerAngles = fire.transform.eulerAngles;
            leftFire.transform.eulerAngles += new Vector3(0, 0, -30);

            //방향에 따른 파이어볼 생성
            GameObject rightFire = Instantiate(fire);

            //발사각을 계산
            rightFire.transform.position = fireBall.transform.position;
            rightFire.transform.eulerAngles = fire.transform.eulerAngles;
            rightFire.transform.eulerAngles += new Vector3(0, 0, 30);

            yield return new WaitForSeconds(DestroyCycle);
            Destroy(fireBall);
            Destroy(leftFire);
            Destroy(rightFire);

            yield return new WaitForSeconds(ShotCycle);
        }
    }
    
}
