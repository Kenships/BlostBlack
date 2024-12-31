using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject pointerVisual;

    private void Update()
    {
        Vector3 pointerPosition = Input.mousePosition;
        pointerVisual.transform.position = pointerPosition;
    }
}
