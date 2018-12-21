using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject UIObj;
    public Sprite swordImg;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (UIObj == null || !UIObj.activeSelf)
            return;

        if (obj.CompareTag("Player"))
        {
            PlayerManager.isAttackAble = true;
            UIObj.SetActive(true);
            UIObj.GetComponent<Image>().sprite = swordImg;
            if(obj.GetComponent<CoinSpin>() != null)
            Destroy(obj.GetComponent<CoinSpin>());
            UIObj.transform.eulerAngles = new Vector3(0, 0, 0);
            Destroy(gameObject);
        }
    }
}
