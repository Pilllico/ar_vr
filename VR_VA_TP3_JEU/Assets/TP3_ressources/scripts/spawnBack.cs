using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBack : MonoBehaviour
{
    GameObject player;
    public float x;
    public float y;
    public float z;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = new Vector3(x, y, z);
    }
}
