using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
{
    [Header("Coin Pickup")] 
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Level.inst.UpdateCoinCounter(value);
            Destroy(gameObject);
        }
    }
}
