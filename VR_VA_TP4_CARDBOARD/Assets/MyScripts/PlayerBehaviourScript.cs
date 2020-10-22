using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public static bool walking = true;
    private Vector3 spawnPoint;
    private Camera mainCamera;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        spawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            transform.position = transform.position + mainCamera.transform.forward * speed * Time.deltaTime;
        }
        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }
    }
}