using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected int cnt;
    [SerializeField]
    protected Transform mTransform = null;
    [SerializeField]
    protected GameObject obj;
    protected List<GameObject> mListPool = new List<GameObject>();
    /// <summary>
    /// 정해진 cnt만큼 obj를 생성한다. 
    /// </summary>
    private GroundMonster groundMonster;
    protected void Awake()
    {
        groundMonster = GetComponent<GroundMonster>();
        for (int i = 0; i < cnt; i++)
        {
            GameObject clones = Instantiate(obj) as GameObject;
            clones.GetComponent<Bullet>().onBackup.AddListener(PushObject);
            clones.GetComponent<Bullet>().groundMonster = groundMonster;
            PushObject(clones);
            clones.transform.parent = gameObject.transform.parent;
        }
    }
    /// <summary>
    /// GameObject를 retrun 해주고 
    /// </summary>
    /// <returns>The object.</returns>
    public virtual GameObject PopObject()
    {
        GameObject temp;
        if (mListPool.Count > 0)
        {
            temp = mListPool[0];
            //리스트에서 제거
            mListPool.RemoveAt(0);
        }
        else
        {   //없을 경우 만들어서 반환
            Debug.Log("test");
            temp = Instantiate(obj) as GameObject;
           // temp.gameObject.transform.SetParent(mTransform);
            temp.GetComponent<Bullet>().onBackup.AddListener(PushObject);
            temp.GetComponent<Bullet>().groundMonster = groundMonster;
        }

        temp.SetActive(true);
        return temp;
    }
    public virtual void PushObject(GameObject obj)
    {
        mListPool.Add(obj);
        //obj.gameObject.transform.SetParent(mTransform);
        obj.gameObject.SetActive(false);
    }
}
