using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int nbObjects;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float y;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nbObjects; i++) {
            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
            Instantiate(prefab, randomPos, prefab.transform.rotation);
        }
    }
}