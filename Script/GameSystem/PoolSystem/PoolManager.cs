using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] enemyPools;
    [SerializeField] Pool[] playerProjectilePools;
    [SerializeField] Pool[] enemyProjectilePools;
    [SerializeField] Pool[] VFXPools;
    [SerializeField] Pool[] lootItemPools;
    static Dictionary<string, Pool> dic;
    private void Awake()
    {
        dic = new Dictionary<string, Pool>();
        Init(enemyPools);
        Init(playerProjectilePools);
        Init(enemyProjectilePools);
        Init(VFXPools);
        Init(lootItemPools);
        EventCenter.AddListener<GameObject, Vector3, float>(EventType.PoolSystem_GetGameObject, GetDelegate);
        EventCenter.AddListener<string, GameObject>(EventType.PoolSystem_RecycleGameObject, RecycleDelegate);
    }
    public void Init(Pool[] pools)
    {
        foreach (Pool pool in pools)
        {
            if (dic.ContainsKey(pool.Prefab.name)) continue;
            dic.Add(pool.Prefab.name, pool);
            Transform poolParent = new GameObject("PoolName: " + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }
    private static GameObject GetGameObject(GameObject prefab, Vector3 pos, float rotZ)
    {
        return dic[prefab.name].EnablePre(pos, rotZ);
    }
    private static void RecycleGameObject(string poolName,GameObject prefab)
    {
        dic[poolName].RecyclePreFab(prefab);
    }
    // 通过监听调用
    private void GetDelegate(GameObject prefab, Vector3 pos, float rotZ)
    {
        GetGameObject(prefab, pos, rotZ);
    }
    private static void RecycleDelegate(string poolName,GameObject prefab)
    {
        RecycleGameObject(poolName, prefab);
    }
}
