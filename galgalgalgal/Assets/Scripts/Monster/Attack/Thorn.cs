using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn: MonoBehaviour {

    public GameObject gameObject;
    public float time;
	public void OnEnable()
	{
		
	}
    IEnumerator OnAction()
    {
        float deltaTimes=0;
        while(deltaTimes<=time)
        {
            deltaTimes += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

    }

}
