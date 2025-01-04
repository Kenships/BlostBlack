using UnityEngine;

[CreateAssetMenu(fileName = "GridSettingsSO", menuName = "Scriptable Objects/GridSettingsSO")]
public class GridSettingsSO : ScriptableObject
{
    public int localGridSize;
    public float gridUnitSize;
    public float gridVisualSpacing;
}
