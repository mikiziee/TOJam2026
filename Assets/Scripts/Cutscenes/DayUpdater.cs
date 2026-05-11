using TMPro;
using UnityEngine;

public class DayUpdater : MonoBehaviour
{
    
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = $"Day {Globals.currentDay}";
        Globals.nextScene = "ForestScene";
    }
}
