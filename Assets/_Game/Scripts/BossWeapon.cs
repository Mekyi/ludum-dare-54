using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform _bulletSpawner;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletInterval = 1f;

    private float _bulletCooldownTimer;
    private GameObject _player;


    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;  
    }

    void Update()
    {
        ShootBulletAtPlayer();
    }

    private void ShootBulletAtPlayer()
    {
        _bulletCooldownTimer -= Time.deltaTime;

        if (_bulletCooldownTimer > 0 ) 
        {
            return;
        }

        _bulletCooldownTimer = _bulletInterval;

        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, _bulletSpawner.rotation);

        if (_player != null )
        {
            bullet.GetComponent<BulletMovement>().SetTarget(_player.transform);
        }
        else
        {
            Debug.LogWarning("Player reference not set");
        }

    }
}
