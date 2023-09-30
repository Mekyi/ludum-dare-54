using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _baseMovementSpeed = 10f;

    private bool _canMove = true;

    private void OnEnable()
    {
        Player.OnPlayerDead += DisableMovement;
    }

    private void OnDisable()
    {
        Player.OnPlayerDead -= DisableMovement;
    }

    void Start()
    {
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_canMove != true) 
        {
            return;
        }

        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMove, 0f, zMove).normalized;

        transform.Translate(movement * _baseMovementSpeed * Time.deltaTime, Space.World);
    }

    private void DisableMovement()
    {
        _canMove = false;
    }
}
