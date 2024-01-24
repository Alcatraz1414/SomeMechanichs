using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObject;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;
    
    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {     
            pools[j].pooledObject = new Queue<GameObject>();

            for(int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);
                obj.SetActive(false);
                pools[j].pooledObject.Enqueue(obj);
            }
        }
    }

    public GameObject GetPoolObject(int objectType)
    {
        if (objectType>= pools.Length)
        {
            return null;
        }

        GameObject obj = pools[objectType].pooledObject.Dequeue();
        obj.SetActive(true);
        pools[objectType].pooledObject.Enqueue(obj);
        return obj;
    }
}
