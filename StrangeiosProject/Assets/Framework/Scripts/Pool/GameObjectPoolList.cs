using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolList : ScriptableObject //继承ScriptableObject，可以把类GameObjectPoolList变成可以自定义资源配置的文件
{
    public List<GameObjectPool> poolList = new List<GameObjectPool>();
}