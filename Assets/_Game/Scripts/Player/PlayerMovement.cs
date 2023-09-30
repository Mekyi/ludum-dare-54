using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _baseMovementSpeed = 10f;

    [SerializeField]
    private float _dashTime = 11f;

    [SerializeField]
    private float _dashSpeed = 12f;

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
        transform.rotation = Quaternion.LookRotation(-movement); // turns character model in the direction it is moving in

        if (Input.GetKeyDown(KeyCode.Space)) // calls the dodge function to dodge in movement direction
        {
            StartCoroutine(Dodge(movement));
        }

        transform.Translate(movement * _baseMovementSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator Dodge(Vector3 movement) // moves character in movement direction for a set distance?
    {

        float startTime = Time.time;
        while (Time.time < startTime + _dashTime)
        {
            transform.Translate(movement * _dashSpeed * Time.deltaTime, Space.World); // increases movement speed for a set time
            yield return null;
        }
    }

    private void DisableMovement()
    {
        _canMove = false;
    }
}
