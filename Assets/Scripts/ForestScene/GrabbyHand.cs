using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GrabbyHand : MonoBehaviour
{
    public InputSystem_Actions controls;
    AudioManager audioManager;

    private InputAction interact, interactAction;

    public GameObject neutral, grab;

    public PhysicsRaycaster raycaster;
    public RaycastHit hit;
    public float maxDistance = 100f;
    public bool yellowCrosshair = false, isGoat = false;
    public Image crosshair;
    public AudioSource baa;

    public GameObject backpack;
    public TrinketManager trinketSpawner;
    public GameObject playerController;
    public GameObject fullIndicator;
    public GameObject tutorialObj;

    public GrabbyHand otherHand;
    public bool backpackFull = false;


    [SerializeField] private LayerMask targetLayer;

    private void Awake()
    {
        controls = new InputSystem_Actions();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            audioManager.Play2DSFX(audioManager.grab);
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
                        Grab();
                    }
                }               
            }
        }
    }

    private void Start() //for btn release
    {
        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor
        Cursor.visible = false;
        interactAction = controls.FindAction("Interact");

        //System.Array.Clear(Globals.inventory, 0, Globals.inventory.Length); <=== swapped array to list so im gonne use the next line instead
        Globals.inventory.Clear();

        Globals.inventoryIndex = 0;

        if (Globals.currentDay == 1)
        {
            tutorialObj.SetActive(true);
        }
    }

    public void Grab()
    {
        pickupsSO pickup = hit.collider.gameObject.GetComponent<pickupsSO>();
        //backpack.SetActive(true);
        backpack.GetComponent<CanvasGroup>().alpha = 1;
        trinketSpawner = backpack.transform.Find("BackpackContainer/TrinketManager").gameObject.GetComponent<TrinketManager>();

        if (backpackFull)
        {
            //backpack.SetActive(false);
            backpack.GetComponent<CanvasGroup>().alpha = 0;
            fullIndicator.SetActive(true);
        }
        else
        {
            Debug.Log(pickup + " " + pickup.GetItemCode());
            trinketSpawner.currentObj = pickup.GetItemCode();
            playerController.SetActive(false);
            interact.Disable();
            neutral.SetActive(false);
            grab.SetActive(true);
            otherHand.interact.Disable();
            otherHand.neutral.SetActive(false);
            otherHand.grab.SetActive(true);
            Destroy(hit.collider.gameObject);
        }
    }

    public void Close()
    {
        playerController.SetActive(true);
        interact.Enable();
        otherHand.interact.Enable();
        neutral.SetActive(true);
        grab.SetActive(false);
        otherHand.neutral.SetActive(true);
        otherHand.grab.SetActive(false);
        //backpack.SetActive(false);
        backpack.GetComponent<CanvasGroup>().alpha = 0;
        
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

    public void SetBackpackFull(bool full)
    {
        backpackFull = full;
    }
}
