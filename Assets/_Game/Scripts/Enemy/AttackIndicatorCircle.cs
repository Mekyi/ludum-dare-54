using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIndicatorCircle : MonoBehaviour
{
    [SerializeField]
    private float _attackTimer = 5f;

    [SerializeField]
    private Transform _snapshotIndicator;

    [SerializeField]
    private Collider _collider;

    [SerializeField]
    [Range(0, 1)]
    private float _indicatorProgress;

    [SerializeField]
    private bool _isLineAoe;

    // Should this gameobject be destroyed or disabled after AoE has happened? 
    private bool _destroyAfterTriggered;
    private AudioSource _damageSound;
    private bool _audioPlayed;

    private void Awake()
    {
        _collider.enabled = false;
        _indicatorProgress = 0;
        _damageSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _indicatorProgress = 0;
        _collider.enabled = false;
        _audioPlayed = false;
    }

    void Update()
    {
        _indicatorProgress += Time.deltaTime / _attackTimer;

        if (_isLineAoe == false)
        {
            _snapshotIndicator.localScale = new Vector3(_indicatorProgress, _indicatorProgress, 0f);
        }
        else
        {
            _snapshotIndicator.localScale = new Vector3(_snapshotIndicator.localScale.x, _indicatorProgress, 0f);
        }
        
        if (_indicatorProgress >= 1)
        {
            _collider.enabled = true;
            StartCoroutine(HandleRemovingAoe());
            if (_audioPlayed == false)
            {
                _damageSound.PlayOneShot(_damageSound.clip);
                _audioPlayed = true;
            }
        }

        _indicatorProgress = Mathf.Clamp(_indicatorProgress, 0, 1);
    }

    public void SetToDestroyAfterSnapshot(bool shouldDestroy)
    {
        _destroyAfterTriggered = shouldDestroy;
    }

    private IEnumerator HandleRemovingAoe()
    {
        yield return new WaitForSeconds(0.5f);

        if (_destroyAfterTriggered)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
