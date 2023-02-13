using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public int value;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
            
        {
            ScoreManager.instance.ChangeCoinScore(coinValue);
            Destroy(gameObject);
           
        }
    }
}
