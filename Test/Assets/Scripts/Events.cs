using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events : MonoBehaviour
{
    public static int coinsCollected = 0;
    public GameObject coinPrefab;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameOver>().OnGameOver();
                Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Coin")
        {
            coinsCollected++;
            GameObject newCoin = Instantiate(coinPrefab,transform.position,Quaternion.identity);
            newCoin.transform.SetParent(transform.parent);
            newCoin.transform.position = new Vector3(newCoin.transform.position.x, newCoin.transform.position.y - (coinsCollected/1.2f), newCoin.transform.position.z);
            newCoin.name = "PlayerCoin ("  + coinsCollected.ToString() + ")";
            newCoin.AddComponent<MainCoinChaser>();
            Destroy(col.gameObject);
            Debug.Log(coinsCollected);
        }
    }
}
