using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ButtonSelfDeleter : MonoBehaviour
{
    [SerializeField] private ParkItemSpawner targetInventoryTetris;
    private bool canBeDeleted = false;

    void Update()
    {
        if (canBeDeleted)
        {
            Debug.Log("update destroying game object...");
            Destroy(gameObject);
        }
    }

    public void CheckCanBeDeleted()
    {
        Debug.Log("Checking if can be deleted...");
        Debug.Log(ParkItemSpawner.Instance.inventoryTetris.TryPlaceItem(ParkItemSpawner.Instance.placedObjectTypeSO as ItemTetrisSO, Vector2Int.zero, ParkItemSpawner.Instance.dir));
        if(ParkItemSpawner.Instance.inventoryTetris.TryPlaceItem(ParkItemSpawner.Instance.placedObjectTypeSO as ItemTetrisSO, Vector2Int.zero, ParkItemSpawner.Instance.dir))
        {
            ParkItemSpawner.Instance.inventoryTetris.RemoveItemAt(Vector2Int.zero);
            canBeDeleted = false;
            Debug.Log("Can be deleted: " + canBeDeleted);
        }
        else
        {
            canBeDeleted = true;
            Debug.Log("Can be deleted: " + canBeDeleted);
            Debug.Log("Destroying game object...");
            Destroy(gameObject);
        }
        
    }
}
