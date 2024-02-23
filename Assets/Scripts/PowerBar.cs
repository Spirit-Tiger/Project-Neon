using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _indicator;
    [SerializeField] 
    private RectTransform _background;
    [SerializeField]
    private PlayerMovement _playerMovement;

    private float _indicatorStartingPoint;

    private void Awake()
    {
        _indicatorStartingPoint = _background.rect.height * -0.5f;
        _indicator.localPosition = new Vector3(0, _indicatorStartingPoint, 0);
    }

    private void Update()
    {
        if (_playerMovement.IsCharging)
        {
            float currentHeight = Mathf.Lerp(_indicatorStartingPoint, _background.rect.height * 0.5f, _playerMovement.PercentageComplete);
            _indicator.localPosition = new Vector3(0, currentHeight, 0);
        }
    }

    private void OnDisable()
    {
        _indicator.localPosition = new Vector3(0, _indicatorStartingPoint, 0);
    }
}
