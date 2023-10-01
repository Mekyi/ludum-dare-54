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

    // Should this gameobject be destroyed or disabled after AoE has happened? 
    private bool _destroyAfterTriggered;

    private void Awake()
    {
        _collider.enabled = false;
        _indicatorProgress = 0;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _indicatorProgress = 0;
        _collider.enabled = false;
    }

    void Update()
    {
        _indicatorProgress += Time.deltaTime / _attackTimer;
        _snapshotIndicator.localScale = new Vector3(_indicatorProgress, _indicatorProgress, 0f);
        
        if (_indicatorProgress >= 1)
        {
            _collider.enabled = true;
            StartCoroutine(HandleRemovingAoe());
        }

        _indicatorProgress = Mathf.Clamp(_indicatorProgress, 0, 1);
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
