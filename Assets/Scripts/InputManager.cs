using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject pointerVisual;
    public static InputManager Instance { get; private set; }
    public event EventHandler OnConfirm;
    InputSystem_Actions inputSystem_Actions;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        inputSystem_Actions = new InputSystem_Actions();
        inputSystem_Actions.Enable();
    }

    private void Start()
    {
        inputSystem_Actions.Player.Confirm.performed += ConfirmOnPerformed;
    }

    private void ConfirmOnPerformed(InputAction.CallbackContext obj)
    {
        OnConfirm?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        Vector3 pointerPosition = Input.mousePosition;
        pointerVisual.transform.position = pointerPosition;
    }

    public Vector3 GetPointerPosition()
    {
        return Input.mousePosition;
    }
    
    
}
