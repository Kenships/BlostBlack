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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TryGetHoverCellLocalCoordinate(out Vector3 localCoordinate))
            {
                OccupyCoordinate(localCoordinate);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (TryGetHoverCellLocalCoordinate(out Vector3 localCoordinate))
            {
                UnOccupyCoordinate(localCoordinate);
            }
        }
    }
    
    
    private void InputOnConfirm(object sender, EventArgs e)
    {
        OutputHoverGridCoordinates();
        //OccupyCoordinate(GetHoverCellLocalCoordinate());
        if (TryGetHoverCellLocalCoordinate(out Vector3 localCoordinate))
        {
            Debug.Log(IsCellOccupied(localCoordinate));
        }
        
    }
    
    private void UpdateHoverCellPosition()
    {
        //Need to check bounds of input
        //meowmeow purr meow meow :3 
        if (TryGetHoverCellLocalCoordinate(out Vector3 localCoordinate))
        {
            if (localCoordinate.x is >= 0 and < GRID_SIZE &&
                localCoordinate.y is >= 0 and < GRID_SIZE)
            {
                gridVisual.transform.position = GetHoverCellWorldPosition();
            }
        }
       
    }

    private void OccupyCoordinate(Vector3 coordinate)
    {
        _gridOccupancy[(int)coordinate.x][(int)coordinate.y] = true;
    }

    private void UnOccupyCoordinate(Vector3 coordinate)
    {
        _gridOccupancy[(int)coordinate.x][(int)coordinate.y] = false;

    }
    private bool IsCellOccupied(Vector3 coordinates)
    {
        return _gridOccupancy[(int)coordinates.x][(int)coordinates.y];
    }

    private bool TryGetHoverCellLocalCoordinate(out Vector3 localCoordinate)
    {
        localCoordinate = GetLocalizedGridCoordinates(GetHoverCellWorldCoordinate());
        if (localCoordinate.x is >= 0 and < GRID_SIZE &&
            localCoordinate.y is >= 0 and < GRID_SIZE)
        {
            return true;
        }
        return false;
    }
    private Vector3 GetHoverCellWorldPosition()
    {
        return gridObject.CellToWorld(GetHoverCellWorldCoordinate());
    }

    private Vector3Int GetHoverCellWorldCoordinate()
    {
        return gridObject.WorldToCell(InputManager.Instance.GetPointerPosition());
    }
    private Vector3 GetLocalizedGridCoordinates(Vector3 worldGridCoordinate)
    {
        Vector3 unitVector = new Vector3(1,1,0);
        return worldGridCoordinate + (GRID_SIZE/2 * unitVector);
    }

    private void InitializeGridOccupancy()
    {
        _gridOccupancy = new bool[GRID_SIZE][];
        for (int row = 0; row < GRID_SIZE; row++)
        {
            _gridOccupancy[row] = new bool[GRID_SIZE];
        }
    }

    private void OutputHoverGridCoordinates()
    {
        Vector3Int worldGridCoordinate = gridObject.WorldToCell(InputManager.Instance.GetPointerPosition());
        Debug.Log("World grid coordinates " + worldGridCoordinate);
        Debug.Log("Local grid coordinate " + GetLocalizedGridCoordinates(worldGridCoordinate));
    }
}
