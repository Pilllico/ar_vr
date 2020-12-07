using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIBehaviour : MonoBehaviour
{
    Text coinText;
    Text timerText;
    GameObject spawnPoint;
    GameObject canvasObj;
    Transform childCoin;
    Transform childTime;
    public int objectif;
    public GameObject fx;
    public GameObject prefab;
    public Animator animator;
    public GameObject canvas;
    GameObject player;
    bool flag = false;

    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.FindWithTag("Player");
        canvasObj = GameObject.Find("Canvas");
        spawnPoint = GameObject.Find("SpawnPoint");

        childCoin = canvasObj.transform.Find("lblCoins");
        coinText = childCoin.GetComponent<Text>();

        childTime = canvasObj.transform.Find("lblTime");
        timerText = childTime.GetComponent<Text>();
        StartCoroutine(TimerTick());
    }

    public void AddCoin()
    {
        GameVariables.nbCoins++;
        coinText.text = "Coins: " + GameVariables.nbCoins;
        if (GameVariables.nbCoins >= objectif && !flag)
        {
            StartCoroutine(Fading());
            flag = true;
        }
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time: " + GameVariables.currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("Level1Exploration");

    }
    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitForSeconds(1.1f);
        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;
        int a = 15;
        for (int i = 0; i < a; ++i)
        {
            Vector3 transform = new Vector3(
                player.transform.position.x + 2 * i - a,
                player.transform.position.y - a,
                player.transform.position.z - a);
            Instantiate(fx, transform, fx.transform.rotation);
        }
        int x = 96;
        int y = 81;
        int z = 32;
        int wait = 10;

        animator.SetBool("Fade", false);

        while (wait > 0)
        {
            yield return new WaitForSeconds(1);
            wait--;
        }

        Vector3 randomPos = new Vector3(x, y, z);
        prefab.transform.localScale.Set(5.0f, 5.0f, 5.0f);
        Instantiate(prefab, randomPos, prefab.transform.rotation);
        Instantiate(canvas, canvas.transform.position, canvas.transform.rotation);

    }
}