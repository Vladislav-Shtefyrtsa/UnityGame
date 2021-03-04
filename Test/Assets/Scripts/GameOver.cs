using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public Text coinscollected;
    public GameObject player;
    bool gameEnd;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (gameOver.activeSelf)
                    {
                        Events.coinsCollected = 0;

                        SceneManager.LoadScene(0);
                    }
                    break;
            }
        }
    }

    public void OnGameOver()
    {
        gameOver.SetActive(true);
        coinscollected.text = Events.coinsCollected.ToString();
    }
}
