using UnityEngine;

public class buttonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonPrefab;

    void Awake()
    {
        for (int i = 0; i < Globals.inventory.Count; i++)
        {
            Instantiate(buttonPrefab[Globals.inventory[i]], transform).SetActive(true);
            Debug.Log("Spawned button for item index: " + Globals.inventory[i]);
        }
    }
}


