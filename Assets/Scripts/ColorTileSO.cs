using UnityEngine;

[CreateAssetMenu(fileName = "ColorTileSO", menuName = "Scriptable Objects/ColorTileSO")]
public class ColorTileSO : ScriptableObject
{
    public Sprite sprite;
    public ColorType color;
    public enum ColorType
    {
        Blue, LightBlue, Green, Yellow, Red, Purple, Orange, Default
    }
}


