using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    private InputActionAsset inputActions;
    private float sensX;
    private float sensY;
    private Transform orientation;
    private float xRotation;
    private float yRotation;
    private InputAction lookAction;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void Osable()
    {
        inputActions.FindActionMap("Player").Disable();
    }


    private void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        OnLook(lookAction);
    }
    private void OnLook(InputAction context)
    {
        Vector2 lookValue = context.ReadValue<Vector2>();
        float mouseX = lookValue.x * sensX * Time.deltaTime;
        float mouseY = lookValue.y * sensY * Time.deltaTime;

        yRotation += mouseX;
        xRotation += mouseY;
    }
    
}
