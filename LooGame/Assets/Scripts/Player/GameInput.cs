using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    
    public static GameInput Instance { get; private set; }

    private void Awake() {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    public Vector2 GetMovementVector() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }

    public Vector3 GetMousePosition() {
        Vector3 MousePostion = Mouse.current.position.ReadValue();
        return MousePostion;
    }
}
