using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryTetrisTesting : MonoBehaviour {

    [SerializeField] private Transform outerInventoryTetrisBackground;
    [SerializeField] private InventoryTetris inventoryTetrisTrunk;
    [SerializeField] private InventoryTetris inventoryTetrisFrontMid;
    [SerializeField] private InventoryTetris inventoryTetrisFrontRight;
    [SerializeField] private InventoryTetris inventoryTetrisFrontLeft;
    [SerializeField] private InventoryTetris inventoryTetrisFrontSeatRight;
    [SerializeField] private InventoryTetris inventoryTetrisFrontSeatLeft;
    [SerializeField] private InventoryTetris bagInventoryTetris;
    [SerializeField] private List<string> addItemTetrisSaveList;

    private int addItemTetrisSaveListIndexTrunk;

    private void Start() {
        //outerInventoryTetrisBackground.gameObject.SetActive(false);

        //load bag item for debug
        bagInventoryTetris.Load(addItemTetrisSaveList[addItemTetrisSaveListIndexTrunk]);
        addItemTetrisSaveListIndexTrunk = (addItemTetrisSaveListIndexTrunk + 1) % addItemTetrisSaveList.Count;

        if(Globals.currentDay > 1)
        {
            inventoryTetrisTrunk.Load(Globals.carTetrisSaveList[0]);
            inventoryTetrisFrontMid.Load(Globals.carTetrisSaveList[1]);
            inventoryTetrisFrontRight.Load(Globals.carTetrisSaveList[2]);
        }


    }

    private void Update() {
    //     if (Keyboard.current.spaceKey.wasPressedThisFrame) {
    //         outerInventoryTetrisBackground.gameObject.SetActive(true);
    //         outerInventoryTetris.Load(addItemTetrisSaveList[addItemTetrisSaveListIndex]);

    //         addItemTetrisSaveListIndex = (addItemTetrisSaveListIndex + 1) % addItemTetrisSaveList.Count;
    //     }

        if (Keyboard.current.pKey.wasPressedThisFrame) {
            // Globals.carTetrisSaveList[0] = inventoryTetrisTrunk.Save();
            // Debug.Log("Saved Car Trunk Inventory: " + Globals.carTetrisSaveList[0]);
            // Globals.carTetrisSaveList[1] = inventoryTetrisFrontMid.Save();
            // Debug.Log("Saved Car Front Mid Inventory: " + Globals.carTetrisSaveList[1]);  
            // Globals.carTetrisSaveList[2] = inventoryTetrisFrontRight.Save();
            // Debug.Log("Saved Car Front Right Inventory: " + Globals.carTetrisSaveList[2]);

            float points = inventoryTetrisTrunk.ReturnPoints() + inventoryTetrisFrontMid.ReturnPoints() +inventoryTetrisFrontRight.ReturnPoints() + inventoryTetrisFrontLeft.ReturnPoints() + inventoryTetrisFrontSeatRight.ReturnPoints() + inventoryTetrisFrontSeatLeft.ReturnPoints();
            Debug.Log("points: " + points);
        }
    }

    public void SaveCarInventory() {
        /*Globals.carTetrisSaveList[0] = inventoryTetrisTrunk.Save();
        Debug.Log("Saved Car Trunk Inventory: " + Globals.carTetrisSaveList[0]);
        Globals.carTetrisSaveList[1] = inventoryTetrisFrontMid.Save();
        Debug.Log("Saved Car Front Mid Inventory: " + Globals.carTetrisSaveList[1]);  
        Globals.carTetrisSaveList[2] = inventoryTetrisFrontRight.Save();*/
    }

    public float TotalPoints(){//(string[] penaltyItemNames, int pointsToDeduct) {
        float points = inventoryTetrisTrunk.ReturnPoints() + inventoryTetrisFrontMid.ReturnPoints() +inventoryTetrisFrontRight.ReturnPoints() + inventoryTetrisFrontLeft.ReturnPoints() + inventoryTetrisFrontSeatRight.ReturnPoints() + inventoryTetrisFrontSeatLeft.ReturnPoints();

        //if(inventoryTetrisTrunk.isPenaltyItemPlaced(penaltyItemNames) || inventoryTetrisFrontMid.isPenaltyItemPlaced(penaltyItemNames) || inventoryTetrisFrontRight.isPenaltyItemPlaced(penaltyItemNames) || inventoryTetrisFrontLeft.isPenaltyItemPlaced(penaltyItemNames) || inventoryTetrisFrontSeatRight.isPenaltyItemPlaced(penaltyItemNames) || inventoryTetrisFrontSeatLeft.isPenaltyItemPlaced(penaltyItemNames))
        //{
        //    points = points - pointsToDeduct;
        //}
        //Debug.Log("points: " + points);
        return points;
    }
}
