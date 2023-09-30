using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _baseMovementSpeed = 10f;

    void Start()
    {
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMove, 0f, zMove).normalized;

        transform.Translate(movement * _baseMovementSpeed * Time.deltaTime, Space.World);
    }
}
