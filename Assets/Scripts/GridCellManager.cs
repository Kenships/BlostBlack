using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridCellManager : MonoBehaviour
{
    private const int GRID_SIZE = 8 ;
    [SerializeField] private GameObject gridVisual; 
    [SerializeField] private Grid gridObject;
    private bool [][] _gridOccupancy;

    private void Awake()
    {
        InitializeGridOccupancy();
    }
    private void Start()
    {
        InputManager.Instance.OnConfirm += InputOnConfirm;
    }

    private void Update()
    {
        UpdateHoverCellPosition();
    }
    
    
    private void InputOnConfirm(object sender, EventArgs e)
    {
        OutputHoverGridCoordinates();
        OccupyPosition(GetHoverCellLocalPosition());
    }
    
    private void UpdateHoverCellPosition()
    {
        //Need to check bounds of input
        gridVisual.transform.position = GetHoverCellWorldPosition();
    }

    private void OccupyPosition(Vector3 position)
    {
        
    }

    private bool IsCellOccupied(Vector3 coordinates)
    {
        return false;
    }

    private Vector3 GetHoverCellLocalPosition()
    {
        return GetLocalizedGridCoordinates(GetHoverCellWorldPosition());
    }
    private Vector3 GetHoverCellWorldPosition()
    {
        return gridObject.CellToWorld(gridObject.WorldToCell(InputManager.Instance.GetPointerPosition()));
    }
    
    private Vector3 GetLocalizedGridCoordinates(Vector3 worldGridCoordinate)
    {
        Vector3 unitVector = new Vector3(1,1,0);
        return worldGridCoordinate + (GRID_SIZE/2 * unitVector);
    }

    private void InitializeGridOccupancy()
    {
        
    }

    private void OutputHoverGridCoordinates()
    {
        Vector3Int worldGridCoordinate = gridObject.WorldToCell(InputManager.Instance.GetPointerPosition());
        Debug.Log("World grid coordinates " + worldGridCoordinate);
        Debug.Log("Local grid coordinate " + GetLocalizedGridCoordinates(worldGridCoordinate));
    }
}
