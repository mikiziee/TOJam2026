using UnityEngine;
using UnityEngine.InputSystem;

public class GrabbyHand : MonoBehaviour
{
    public InputSystem_Actions controls;

    private InputAction interact, interactAction;

    public GameObject neutral, grab;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        interact = controls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        interact.Disable();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            neutral.SetActive(false);
            grab.SetActive(true);
        }
    }

    private void Start() //for btn release
    {
        interactAction = controls.FindAction("Interact");
    }

    private void Update()
    {
        if (interact.WasCompletedThisFrame()) //on btn release
        {
            neutral.SetActive(true);
            grab.SetActive(false);
        }
    }
}
