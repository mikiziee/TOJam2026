using UnityEngine;

public class TrinketManager : MonoBehaviour
{
    private GameObject lastSpawnedTrinket;
    [SerializeField] private GameObject[] trinketPrefabs;

    public void SpawnTrinket(int trinketId)
    {
        Instantiate(trinketPrefabs[trinketId], transform.position, Quaternion.identity);
        lastSpawnedTrinket = trinketPrefabs[trinketId];
    }
    
    void Start()
    {
        
        for (int i = 0; i < trinketPrefabs.Length; i++)
        {
            SpawnTrinket(i); // Example: Spawn the first trinket at the start
            Debug.Log($"Trinket {i}: {trinketPrefabs[i].name}");
        }
    }


}
