using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        AdjustPlayerFacingDirection(); 
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 MousePosition = GameInput.Instance.GetMousePosition();
        Vector3 PlayerPosition = Player.Instance.GetPlayerPostion();
        Vector2 PlayerSee = GameInput.Instance.GetMovementVector();

        if (MousePosition.x < PlayerPosition.x || PlayerSee.x < 0) {
            spriteRenderer.flipX = true;
        } 
        else {
            spriteRenderer.flipX = false;
        }
    }
}
