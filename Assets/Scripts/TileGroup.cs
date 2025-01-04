using System;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour, IGridPlaceable
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] List<Vector2Int> tilePositions;
    [SerializeField] RectTransform tileParentTransform;
    [SerializeField] private GridSettingsSO gridSettings;
    [SerializeField] ColorLibrarySO colorLibrary;
    private bool _mirrored;
    private List<GridTile> _tiles;

    private void Awake()
    {
        _tiles = new List<GridTile>();
    }
    private void Start()
    {
        tileParentTransform.position += (gridSettings.gridUnitSize/2)* Vector3.one;
        ColorTileSO colorTile = colorLibrary.GetRandomColorTile();
        for (int i = 0; i < tilePositions.Count; i++)
        {
            GridTile tile = Instantiate(tilePrefab, tileParentTransform).GetComponent<GridTile>();
            tile.ChangeColor(colorTile);
            _tiles.Add(tile);
        }

        RepositionTiles();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            tilePositions = IGridPlaceable.RotateCoordinatesClockWise(tilePositions, 90);
            RepositionTiles();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            tilePositions = IGridPlaceable.MirrorCoordinates(tilePositions);
            RepositionTiles();
        }
    }

    private void RepositionTiles()
    {
        for(int i = 0; i < _tiles.Count; i++){
            GridTile tile = _tiles[i];
            Vector3 position = new Vector3
            {
                x = tilePositions[i].x * gridSettings.gridUnitSize,
                y = tilePositions[i].y * gridSettings.gridUnitSize
            };
            tile.transform.position = tileParentTransform.position + position;
        }
    }
    
    public List<Vector2Int> GetLocalGridCoordinates()
    {
        
        return tilePositions;
    }
}
