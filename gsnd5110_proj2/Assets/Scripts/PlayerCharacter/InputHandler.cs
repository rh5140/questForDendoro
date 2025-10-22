using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] CharacterMovement cm;
    [SerializeField] CharacterInteraction ci;
    
    private InputAction _moveAction;
    private InputAction _interactAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _interactAction = InputSystem.actions.FindAction("Interact");

        _interactAction.performed += TryInteract;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        cm.Move(movementVector);
    }

    private void TryInteract(InputAction.CallbackContext context)
    {
        ci.Interact();
    }

    private void OnDisable()
    {
        _interactAction.performed -= TryInteract;
    }
}
