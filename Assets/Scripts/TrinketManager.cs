using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrinketManager : MonoBehaviour
{
    private GameObject lastSpawnedTrinket;
    [SerializeField] private GameObject[] trinketPrefabs;
    [SerializeField] private GameObject lid;
    

    /* void Start()
    {
        
        for (int i = 0; i < trinketPrefabs.Length; i++)
        {
            SpawnTrinket(i); // Example: Spawn the first trinket at the start
            Debug.Log($"Trinket {i}: {trinketPrefabs[i].name}");
        }
    } */

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnRandomTrinket();
        }
    }

    public bool SpawnTrinket(int trinketId)
    {
        if (!lid.GetComponent<Lid>().GetIsFull())
        {
            GameObject trinket;
            Debug.Log($"Spawning trinket with ID: {trinketId}");
            trinket = Instantiate(trinketPrefabs[trinketId], transform.position, Quaternion.identity, transform.parent);
            lastSpawnedTrinket = trinketPrefabs[trinketId];
            return true;
        }
        else
        {
            Debug.Log("Cannot spawn trinket: Lid is full!");
            return false;
        }
        
    }
    
    
    public void SpawnRandomTrinket()
    {
        Debug.Log("Spawning random trinket...");
        SpawnTrinket(Random.Range(0, trinketPrefabs.Length));
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
