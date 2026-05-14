using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GrabbyHand : MonoBehaviour
{
    public InputSystem_Actions controls;

    private InputAction interact, interactAction;

    public GameObject neutral, grab;

    public PhysicsRaycaster raycaster;
    public RaycastHit hit;
    public float maxDistance = 100f;
    public bool yellowCrosshair = false, isGoat = false;
    public Image crosshair;
    public AudioSource baa;

    public GameObject backpack;
    public GameObject playerController;

    public GrabbyHand otherHand;

    [SerializeField] private LayerMask targetLayer;

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

            if (raycaster)
            {
                if (Physics.Raycast(raycaster.transform.position, raycaster.transform.forward, out hit, maxDistance, targetLayer))
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    if (isGoat)
                    {
                        baa.Stop();
                        baa.time = 0.4f;
                        baa.Play();
                    }
                    else
                    {
                        backpack.SetActive(true);
                        playerController.SetActive(false);
                        interact.Disable();
                        neutral.SetActive(true);
                        grab.SetActive(false);
                        otherHand.interact.Disable();
                        otherHand.neutral.SetActive(true);
                        otherHand.grab.SetActive(false);
                    }
                }               
            }
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

        if (raycaster)
        {
            if (Physics.Raycast(raycaster.transform.position, raycaster.transform.forward, out hit, maxDistance, targetLayer) && !yellowCrosshair)
            {
                //Debug.Log("Test");
                if (hit.collider.gameObject.CompareTag("Goat"))
                {
                    crosshair.color = Color.magenta;
                    isGoat = true;
                }
                else
                {
                    crosshair.color = Color.yellow;
                }                    
            }
            else
            {
                crosshair.color = Color.white;
                isGoat = false;
            }
        }
    }
}
