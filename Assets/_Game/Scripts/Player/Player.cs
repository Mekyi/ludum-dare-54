using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Game.Tags.Enemy)
        {
            // Player is dead. Send event of this
            OnPlayerDead?.Invoke();
        }
    }
}
