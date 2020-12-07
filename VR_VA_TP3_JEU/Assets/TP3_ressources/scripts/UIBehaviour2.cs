using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIBehaviour2 : MonoBehaviour
{
    Text coinText;
    Text timerText;
    GameObject canvasObj;
    public GameObject gameOver;
    Transform childCoin;
    Transform childTime;
    // Start is called before the first frame update
    void Start()
    {
        canvasObj = GameObject.Find("Canvas");
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);

        childCoin = canvasObj.transform.Find("lblCoins");
        coinText = childCoin.GetComponent<Text>();
        coinText.text = "Coins: " + GameVariables.nbCoins;

        childTime = canvasObj.transform.Find("lblTime");
        timerText = childTime.GetComponent<Text>();

        StartCoroutine(TimerTick());
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
        gameOver.SetActive(true);

    }

    public void endGame()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene("Level1Exploration");
    }

}
