using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorLibrarySO", menuName = "Scriptable Objects/ColorLibrarySO")]
public class ColorLibrarySO : ScriptableObject
{
    [SerializeField] private List<ColorTileSO> spriteTiles;
    
    
    
    public ColorTileSO GetRandomColorTile()
    {
        return spriteTiles[Random.Range(1, spriteTiles.Count)];
    }

    public ColorTileSO GetColorTile(ColorTileSO.ColorType colorType)
    {
        foreach (ColorTileSO colorTile in spriteTiles)
        {
            if (colorTile.color == colorType)
            {
                return colorTile;
            }
        }
        
        //returns default
        return spriteTiles[0];
    }
}
