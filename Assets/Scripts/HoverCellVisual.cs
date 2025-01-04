using System;
using UnityEngine;

public class HoverCellVisual : MonoBehaviour
{
    [SerializeField] GridSettingsSO gridSettings;
    [SerializeField] RectTransform rectTransform;
    private void Start()
    {
        rectTransform.sizeDelta = gridSettings.gridUnitSize * Vector2.one;
    }
}
