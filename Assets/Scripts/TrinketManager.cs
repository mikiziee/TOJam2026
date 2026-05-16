using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrinketManager : MonoBehaviour
{
    private GameObject lastSpawnedTrinket;
    [SerializeField] private GameObject[] trinketPrefabs;
    [SerializeField] private GameObject lid;
    public int currentObj = 0;
    public GameObject trinket;
    public GrabbyHand hand;
    public bool isFull = false, hasSpawned = false;

    public InputSystem_Actions controls;
    private InputAction left, right;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        left = controls.Player.LeftInteract;
        right = controls.Player.Interact;
        left.Enable();
        right.Enable();
    }

    private void OnDisable()
    {
        left.Disable();
        right.Disable();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !hasSpawned)
        {
            SpawnRandomTrinket();
            hasSpawned = true;
        }

        if (left.IsPressed() && transform.localPosition.x >= -2)
        {
            transform.localPosition = transform.localPosition - new Vector3(0.01f, 0, 0);
        }

        if (right.IsPressed() && transform.localPosition.x <= 2)
        {
            transform.localPosition = transform.localPosition + new Vector3(0.01f, 0, 0);
        }

        if (trinket != null && trinket.GetComponent<Rigidbody2D>().IsSleeping())
        {
            trinket = null;
            hasSpawned = false;
            hand.Close();
        }

        if (lid.GetComponent<Lid>().GetIsFull())
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
    }



    public void SpawnTrinket(int trinketId)
    {
        if (!lid.GetComponent<Lid>().GetIsFull())
        {           
            //Debug.Log($"Spawning trinket with ID: {trinketId}");
            trinket = Instantiate(trinketPrefabs[trinketId], transform.position, Quaternion.identity, transform.parent);

            Globals.inventory.Add(currentObj);
            
            // Globals.inventory[Globals.inventoryIndex] = currentObj; <===== was used for arry but i switched it to list
            // Globals.inventoryIndex++;
            
        }
    }

    public void SpawnRandomTrinket()
    {
        SpawnTrinket(currentObj);
    }

    void TrySelectObjectAtMouse()
    {
        // Convert mouse position from screen space to world space
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Perform a 2D raycast at the mouse position
        //RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero); // Adjust layer mask as needed

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        var hit = Physics2D.GetRayIntersection(ray, 1500f);

        //Debug.Log(hit.rigidbody);
        //Debug.Log("aaaaaaa");

        if (hit.collider.CompareTag("BackpackItem"))
        {
            Debug.Log("Clicked on object: " + hit.collider.name);

            // Example: highlight or interact with the object
            hit.collider.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            Debug.Log("No object at mouse position.");
        }
    }

    void TrySelectUIAtMouse()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("BackpackItem"))
            {
                result.gameObject.GetComponent<Image>().color = Color.yellow;
            }
        }
    }

}
