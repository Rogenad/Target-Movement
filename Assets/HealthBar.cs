﻿using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Camera _mainCamera;
    private RectTransform _healthBarPosition;
    private Transform _healthBarOwner;
    private RectTransform _targetCanvas;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        RepositionHealthBar();
    }
    
    public void SetHealthBarData(Transform healthBarOwner, RectTransform healthBarPanel)
    {
        _healthBarOwner = healthBarOwner;
        _healthBarPosition = GetComponent<RectTransform>();
        _targetCanvas = healthBarPanel;
        _healthBarPosition.gameObject.SetActive(true);
        RepositionHealthBar();
    }
    
    private void RepositionHealthBar()
    {
        var canvasSizeDelta = _targetCanvas.sizeDelta;
        
        Vector2 viewportPosition = _mainCamera.WorldToViewportPoint(_healthBarOwner.position);
        var worldObjectScreenPosition = new Vector2(
            ((viewportPosition.x * canvasSizeDelta.x) - (canvasSizeDelta.x * 0.5f)),
            ((viewportPosition.y * canvasSizeDelta.y) - (canvasSizeDelta.y * 0.5f)));
        _healthBarPosition.anchoredPosition = worldObjectScreenPosition;
    }

    
}
