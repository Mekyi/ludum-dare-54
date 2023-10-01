using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    private Transform _player;
    private string _name;

    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        transform.LookAt(_player);
    }
}
