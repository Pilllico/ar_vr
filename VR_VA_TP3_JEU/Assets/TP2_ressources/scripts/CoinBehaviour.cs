using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public GameObject fx;
    GameObject worldObject;
    GameObject audioObject;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        worldObject = GameObject.Find("World");
        audioObject = GameObject.Find("Audio");// votre GameObject contenant l’Audio source
        aud = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {   // OnCollisionEnter
        worldObject.SendMessage("AddCoin");
        if (aud){
            aud.Play();
        }
        Instantiate(fx, transform.position, fx.transform.rotation);
        Destroy(gameObject);
    }
}
