using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private static Dictionary<string, List<GameObject>> _pooledObjects = new Dictionary<string, List<GameObject>>();


    public static void Add<T>(GameObject prefab, int count = 10)
    {
        try
        {
            string key = typeof(T).Name;
            if (!_pooledObjects.ContainsKey(key))
            {
                _pooledObjects.Add(key, new List<GameObject>());
            }

            for (int i = 0; i < count; i++)
            {
                GameObject go = Instantiate(prefab);
                go.SetActive(false);
                _pooledObjects[key].Add(go);

            }
        }
        catch (System.Exception e) {  }
    }    

    public static GameObject Get(string key)
    {
        try
        {
            if (_pooledObjects.ContainsKey(key))
            {
                foreach (GameObject obj in _pooledObjects[key])
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }
            }
        }
        catch (System.Exception e) { }

        Debug.LogErrorFormat("Could not get item with key {0}", key);
        return null;
    }

    public static T Get<T>() where T : class
    {
        try
        {
            string key = typeof(T).Name;
            if (_pooledObjects.ContainsKey(key))
            {
                foreach (GameObject obj in _pooledObjects[key])
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj.GetComponent<T>();
                    }
                }
            }
        }
        catch (System.Exception e) { }
        return null;
    }
}
