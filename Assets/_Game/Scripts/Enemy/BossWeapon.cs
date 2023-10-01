using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [Header("Bullets")]

    [SerializeField]
    private Transform _bulletSpawner;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletInterval = 1f;

    [Header("Arena AoE")]
    
    [SerializeField]
    private AttackIndicatorCircle[] _arenaAoes;

    [SerializeField]
    private float _aoeInterval = 5f;

    [Header("Targeted AoE")]

    [SerializeField]
    private GameObject _targetedAoePrefab;

    [SerializeField]
    private float _targetedAoeInterval = 5f;

    private float _bulletCooldownTimer;
    private float _aoeCooldownTimer;
    private float _targetedAoeCooldownTimer;
    private GameObject _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;  
    }

    private void Start()
    {
        _aoeCooldownTimer = _aoeInterval;
    }

    private void Update()
    {
        ShootBulletAtPlayer();
        ActivateRandomAoes();
        UseTargetedAoes();
    }

    private void UseTargetedAoes()
    {
        _targetedAoeCooldownTimer -= Time.deltaTime;

        if (_targetedAoeCooldownTimer > 0)
        {
            return;
        }

        _targetedAoeCooldownTimer = _targetedAoeInterval;

        GameObject targetedAoe = Instantiate(
                _targetedAoePrefab, 
                new Vector3(_player.transform.position.x, 1f, _player.transform.position.z),
                _targetedAoePrefab.transform.rotation
            );

        // Targeted AoE gameobject should be destroyed at the end of their lifecycle
        targetedAoe.GetComponent<AttackIndicatorCircle>().SetToDestroyAfterSnapshot(true);
    }

    private void ActivateRandomAoes()
    {
        _aoeCooldownTimer -= Time.deltaTime;

        if (_aoeCooldownTimer > 0)
        {
            return;
        }

        _aoeCooldownTimer = _aoeInterval;

        // Activate 1 to 2 random arena AoEs
        for (int i = 0; i < 2; i++)
        {
            var random = new System.Random();
            _arenaAoes[random.Next(0, _arenaAoes.Length)].gameObject.gameObject.SetActive(true);
        }
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
