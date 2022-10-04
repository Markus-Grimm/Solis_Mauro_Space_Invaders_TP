using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObjects, pooledObjects2;
    public GameObject laser, missile;
    public int amountToPool, amountToPool2;


    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(laser);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledObjects2 = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i < amountToPool2; i++)
        {
            tmp2 = Instantiate(missile);
            tmp2.SetActive(false);
            pooledObjects2.Add(tmp2);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < amountToPool2; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        return null;
    }

    void Update()
    {

    }
}
