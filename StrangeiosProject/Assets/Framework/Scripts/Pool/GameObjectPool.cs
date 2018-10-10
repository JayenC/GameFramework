using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 资源池
/// </summary>
[Serializable]
public class GameObjectPool
{
    [SerializeField]
    public string name;
    [SerializeField]
    private int maxAmount;
    [SerializeField]
    private GameObject prefab;

    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();

    public GameObject GetInst()
    {
        foreach (GameObject go in goList)
        {
            if(!go.activeInHierarchy)
            {
                go.SetActive(true);
                return go;
            }
        }

        if(goList.Count >=  maxAmount  )
        {
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }

        GameObject temp = GameObject.Instantiate(prefab);
        goList.Add(temp);
        return temp;
    }
}