using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab => prefab;
    public int PoolSize => poolSize;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize;
    private Queue<GameObject> poolQueue;
    private Transform parent;
    private GameObject Copy()
    {
        GameObject copy = GameObject.Instantiate(prefab, parent);
        copy.SetActive(false);
        return copy;
    }
    public void Initialize(Transform parent)
    {
        this.parent = parent;
        poolQueue = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            poolQueue.Enqueue(Copy());
        }
    }
    public GameObject GetPreFab()
    {
        GameObject availableObject = null;
        if (poolQueue.Count > 0 && poolQueue.Peek().activeSelf == false)
        {
            availableObject = poolQueue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }
        return availableObject;
    }
    public GameObject EnablePre()
    {
        GameObject pre = GetPreFab();
        pre.SetActive(true);
        return pre;
    }
    public GameObject EnablePre(Vector2 position, float rotZ)
    {
        GameObject pre = GetPreFab();
        pre.SetActive(true);
        pre.transform.position = position;
        pre.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        return pre;
    }
    public void RecyclePreFab(GameObject obj)
    {
        if (poolQueue.Contains(obj))
        {
            return;
        }
        else if (poolQueue.Count > poolSize)
        {
            GameObject.Destroy(obj);
        } 
        else 
        {
            poolQueue.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    public void DestroyPool()
    {
        poolQueue.Clear();
    }
}
