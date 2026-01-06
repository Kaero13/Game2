using UnityEngine;

public class ActiveWeapon : MonoBehaviour {
    public static ActiveWeapon Instance { get; private set; }

    [SerializeField] private Sword sword;

    private void Update() {
        PerevorotSword();
    }

    private void Awake() {
        Instance = this;
    }
    public Sword GetActiveWeapon() {
        return sword;
    }
    private void PerevorotSword() {
        Vector3 MousePosition = GameInput.Instance.GetMousePosition();
        Vector3 PlayerPosition = Player.Instance.GetPlayerPostion();
        Vector2 PlayerSee = GameInput.Instance.GetMovementVector();

        if (MousePosition.x < PlayerPosition.x || PlayerSee.x < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
