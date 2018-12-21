using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public GameObject coinObj;
    public Sprite coinImg;
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            coinObj.SetActive(true);
            coinObj.GetComponent<Image>().sprite = coinImg;
            coinObj.AddComponent<CoinSpin>();
            Destroy(gameObject);
        }
    }
}
