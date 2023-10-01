using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2f;

    private Vector3 _movementDirection;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(_movementDirection.x * _movementSpeed * Time.deltaTime, 0f, _movementDirection.z * _movementSpeed * Time.deltaTime, Space.World);
    }

    public void SetTarget(Transform targetLocation)
    {
        Vector3 targetDirection = targetLocation.position - transform.position;
        _movementDirection = targetDirection.normalized;

        var direction = Vector3.RotateTowards(transform.forward, targetDirection, 0f, 0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Game.Tags.Despawner)
        {
            // bullet despawns when it leaves the field
            Destroy(gameObject);
        }

    }

}
