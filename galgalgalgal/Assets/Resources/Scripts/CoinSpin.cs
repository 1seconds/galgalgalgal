using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.eulerAngles += new Vector3(0, 60 * Time.deltaTime, 0);
    }
}
