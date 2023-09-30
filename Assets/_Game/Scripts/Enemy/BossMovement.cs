using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
