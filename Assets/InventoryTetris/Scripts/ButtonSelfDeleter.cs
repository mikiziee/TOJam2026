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


    public void SetCanBeDeleted(bool canBeDeleted)
    {
        this.canBeDeleted = canBeDeleted;
    }
    
    public void CheckCanBeDeleted()
    {
        if(ParkItemSpawner.Instance.inventoryTetris.TryPlaceItem(ParkItemSpawner.Instance.placedObjectTypeSO as ItemTetrisSO, Vector2Int.zero, ParkItemSpawner.Instance.dir) == true)
        {
            ParkItemSpawner.Instance.inventoryTetris.RemoveItemAt(Vector2Int.zero);
            canBeDeleted = true;
        }
        else
        {
            canBeDeleted = false;
        }
        if(canBeDeleted == true)
        {
            Destroy(gameObject);
        }
        
    }
}
