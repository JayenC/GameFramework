using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PoolManager();
            return _instance;
        }
    }

    private static string poolConfigPathPrefix = "Assets/Framework/Resources/";
    private const string poolConfigPathMiddle = "gameobjectPool";
    private const string poolConfigPathPostfix = ".asset";

    public static string poolConfigPath { get { return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix; } }

    private Dictionary<string, GameObjectPool> poolDict = new Dictionary<string, GameObjectPool>();

    private PoolManager()
    {
        GameObjectPoolList goList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);

        foreach (GameObjectPool pool in goList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }

    public void Init()
    {
        //Do nothing
    }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if (poolDict.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }

        Debug.LogWarning("pool:" + poolName + "is not exist!!!");
        return null;
    }

}