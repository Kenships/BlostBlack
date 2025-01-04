using UnityEngine;
using UnityEngine.UI;

public class GridVisual : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] GridLayoutGroup gridLayoutGroup;
    [SerializeField] Grid grid;
    [SerializeField] private GridSettingsSO gridSettings;
    public void Start()
    {
        rectTransform.sizeDelta = (gridSettings.localGridSize * gridSettings.gridUnitSize + gridSettings.gridVisualSpacing) * Vector2.one;
        gridLayoutGroup.cellSize = (gridSettings.gridUnitSize - gridSettings.gridVisualSpacing) * Vector2.one;
        gridLayoutGroup.spacing = gridSettings.gridVisualSpacing * Vector2.one;
        gridLayoutGroup.padding.top = (int) gridSettings.gridVisualSpacing;
        gridLayoutGroup.padding.left = (int) gridSettings.gridVisualSpacing;
        grid.cellSize = gridSettings.gridUnitSize * Vector2.one;
    }
}
