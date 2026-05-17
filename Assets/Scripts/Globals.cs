using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public static class Globals
{
    public static string nextScene;

    public static int currentDay = 1;

    public static List<int> inventory = new List<int>() { 0, 1, 2, 3, 4, 5,6,7,8,9 };
    public static int inventoryIndex = 0;

    public static List<string> carTetrisSaveList =  new List<string>() { "", "", "", "", "", "" };
    public static float points = 0;

}
