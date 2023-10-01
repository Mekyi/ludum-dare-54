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
    private SphereCollider _collider;

    [SerializeField]
    [Range(0, 1)]
    private float _indicatorProgress;


    private void Awake()
    {
        _collider.enabled = false;
        _indicatorProgress = 0;
    }

    void Update()
    {
        _indicatorProgress += Time.deltaTime / _attackTimer;
        _snapshotIndicator.localScale = new Vector3(_indicatorProgress, _indicatorProgress, 0f);
        
        if (_indicatorProgress >= 1)
        {
            _collider.enabled = true;
            Destroy(gameObject, 0.5f);
        }

        _indicatorProgress = Mathf.Clamp(_indicatorProgress, 0, 1);
    }
}