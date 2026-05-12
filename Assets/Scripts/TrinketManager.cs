using UnityEngine;
using UnityEngine.InputSystem;

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

         if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            TrySelectObjectAtMouse();
        }
    }

    public bool SpawnTrinket(int trinketId)
    {
        if (!lid.GetComponent<Lid>().GetIsFull())
        {
            Debug.Log($"Spawning trinket with ID: {trinketId}");
            Instantiate(trinketPrefabs[trinketId], transform.position, Quaternion.identity);
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
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Perform a 2D raycast at the mouse position
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 0f, LayerMask.GetMask("BackpackItems")); // Adjust layer mask as needed

        Debug.Log(hit.rigidbody);
        Debug.Log("aaaaaaa");

        if (hit.rigidbody != null)
        {
            Debug.Log("Clicked on object: " + hit.collider.name);

            // Example: highlight or interact with the object
            // hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Debug.Log("No object at mouse position.");
        }
    }


}
