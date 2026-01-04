using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; }

    [SerializeField] private float standartspeedmul = 5f;
    Vector2 InputVector;

    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    private void Awake() {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        InputVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
        InputVector = InputVector.normalized;
        rb.MovePosition(rb.position + InputVector * (standartspeedmul * Time.fixedDeltaTime));

        if (Mathf.Abs(InputVector.x) > minMovingSpeed || Mathf.Abs(InputVector.y) > minMovingSpeed) {
            isRunning = true;
        } 
        else {
            isRunning = false;
        }
    }

    public bool IsRunning() {
        return isRunning;
    }

    public Vector3 GetPlayerPostion() {
        Vector3 PlayerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return PlayerScreenPosition;
    }
}

