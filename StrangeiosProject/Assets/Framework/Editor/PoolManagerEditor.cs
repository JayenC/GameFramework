using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolManagerEditor
{
    [MenuItem("Manager/Create GameobjectPoolConfig")]
    static void CreateGameobjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();

        AssetDatabase.CreateAsset(poolList, PoolManager.poolConfigPath);
    }
}