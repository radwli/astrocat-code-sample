using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    public PlayerInputActions playerInputActions;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        if (instance == null)
        {
            instance = this;
        }
    }

    public Vector2 GetPointerInput()
    {
        Vector3 mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
