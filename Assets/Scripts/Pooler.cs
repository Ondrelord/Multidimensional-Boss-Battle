using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool of ", menuName = "Pool")]
public class Pooler : ScriptableObject
{
    public GameObject pooledGO;

    //public float timeToDisappear = 0;

    private List<GameObject> pool;

    public void init()
    {
        pool = new List<GameObject>();
    }

    /// Get and Object from a pool of objects if all are in use create new.
    public GameObject GetObject() => GetObject(Vector2.zero, Quaternion.identity, null);
    public GameObject GetObject(Transform parent) => GetObject(Vector2.zero, Quaternion.identity, parent);
    public GameObject GetObject(Vector3 position, Quaternion rotation) => GetObject(position, rotation, null);
    public GameObject GetObject(Vector3 position, Quaternion rotation, Transform parent)
    {
        // finds nonactive object and returns it in desired transform and parent
        foreach (GameObject GO in pool)
        {
            if (!GO.activeSelf)
            {
                GO.transform.SetPositionAndRotation(position, rotation);
                GO.transform.SetParent(parent);
                GO.SetActive(true);
                return GO;
            }
        }

        // if all are active create new object
        GameObject newGO = Instantiate(pooledGO, position, rotation, parent);
        pool.Add(newGO);

        return newGO;
    }

    
}
