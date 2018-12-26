using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadderTopObject : MonoBehaviour
{
    public GameObject obj;

    private void OnEnable()
    {
        if (obj == null)
            obj = gameObject.transform.GetChild(0).gameObject;
    }
}
