using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueTextComponent;
    [SerializeField] TMP_Text dayTextComponent;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Start()
    
    {
        SetDayText();
        switch (Globals.currentDay)
        {
            case 1:
                SetText("You have to leave some behind, sweetie.");
                break;
            case 2:
                SetText("Welcome back! Let's continue our adventure.");
                break;
            case 3:
                SetText("Great to see you again! The story unfolds...");
                break;
            default:
                SetText("Welcome to the game!");
                break;
        }
    }

    private void SetText(string text)
    {
        dialogueTextComponent.text = text;
    }

    private void SetDayText()
    {
        string dayText;
        switch (Globals.currentDay)
        {
            case 1:
                dayText = "ONE";
                break;
            case 2:
                dayText = "TWO";
                break;
            case 3:
                dayText = "THREE";
                break;
            case 4:
                dayText = "FOUR";
                break;
            case 5:
                dayText = "FIVE";
                break;
            case 6:
                dayText = "SIX";
                break;
            case 7:
                dayText = "SEVEN";
                break;
            case 8:
                dayText = "EIGHT";
                break;     
            case 9:
                dayText = "NINE";
                break;
            case 10:
                dayText = "TEN";
                break;   
            case 11:
                dayText = "ELEVEN";
                break;
            case 12:
                dayText = "TWELVE";
                break;
            case 13:    
                dayText = "THIRTEEN";
                break;
            default:
                dayText =  Globals.currentDay.ToString();
                break;
        }
        dayTextComponent.text = "Day " + dayText;
    }


}
