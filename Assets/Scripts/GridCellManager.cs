using System.Collections.Generic;
using UnityEngine;

public class GridCellManager : MonoBehaviour
{
    private const int GRID_SIZE = 8 ;
    [SerializeField] private List<GameObject> gridHolder;
    [SerializeField] private GameObject gridVisual;
    [SerializeField] private GameObject grid;
    private GameObject[][] _gridCellLocations;
    private Vector3 _firstCellLocation;
    private void Start()
    {
        _gridCellLocations = new GameObject[GRID_SIZE][];
        for (int row = 0; row < GRID_SIZE; row ++)
        {
            _gridCellLocations[row] = new GameObject[GRID_SIZE];
            for (int col = 0; col < GRID_SIZE; col++)
            {
                _gridCellLocations[row][col] = gridHolder[row * GRID_SIZE + col];
            }
                
        }

        _firstCellLocation = grid.transform.position;
        Debug.Log(_firstCellLocation);
        gridVisual.transform.position = _firstCellLocation;
    }   
}
