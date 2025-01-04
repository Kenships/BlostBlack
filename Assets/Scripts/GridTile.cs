using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GridTile : MonoBehaviour
{
    [SerializeField] private ColorLibrarySO colorLibrary;
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GridSettingsSO gridSettings;
    private ColorTileSO _setColor;

    private void Start()
    {
        rectTransform.sizeDelta = gridSettings.gridUnitSize * Vector2.one;
        _setColor ??= colorLibrary.GetRandomColorTile();
        UpdateColor();
    }
    
    private void SetColor(ColorTileSO colorTile)
    {
        _setColor = colorTile;
    }

    private void UpdateColor()
    {
        image.sprite = _setColor.sprite;
    }

    public void ChangeColor(ColorTileSO colorTile)
    {
        SetColor(colorTile);
        UpdateColor();
    }

    public ColorTileSO GetColorTile()
    {
        return _setColor;
    }
}
