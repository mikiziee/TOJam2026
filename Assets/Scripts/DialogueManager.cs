using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueTextComponent;
    [SerializeField] TMP_Text dayTextComponent;
    [SerializeField] TMP_Text pointsTextComponent;
    [SerializeField] InventoryTetrisTesting GameScript;

    private string[] penaltyItemNames;
    [SerializeField] private int[] pointsToDeduct = new int[] { 0, 20, 75, 200, 5000 };
    AudioManager audioManager;


    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Start()
    {
        SetDayText();

        switch (Globals.currentDay)
        {
            case 1:
                SetText("Pack your things into the car, honey! Who do you think should drive today? (click on objects to bring them to your grid. drag into available yellow spaces, and passengers into blue seats)");
                penaltyItemNames = new string[] { "None" };
                break;
            case 2:
                SetText("I think your father should drive us home, I've had a really hard day. And don't bring any garbage home with us.");
                penaltyItemNames = new string[] { "Toiletroll" };
                break;
            case 3:
                SetText("We don't need any more pebbles in the house, they're pointless. Leave them in the parking lot.");
                penaltyItemNames = new string[] { "Toiletroll", "Pebble" };
                break;
            case 4:
                SetText("Your shoes are all dirty, I don't want the mud in my car. I'm leaving them outside. Whatever you have in your bag, its not coming home if it isnt cute.");
                penaltyItemNames = new string[] {  "Toiletroll", "Pebble", "Hairbrush", "Sandwich", "ShampooBottle","Stick", "Toothbrush", "WaterBottle" };
                break;
            case 5:
                SetText("You're all dirty from running around in the woods, and you keep bringing garbage home. You're not allowed to get in the car.");
                penaltyItemNames = new string[] {   "Toiletroll", "Pebble", "Hairbrush", "Sandwich", "ShampooBottle","Stick", "Toothbrush", "WaterBottle", "Snail", "RubberDuck"  };
                break;
            default:
                SetText("Pack your things into the car, honey! Who do you think should drive today? (click on objects to bring them to your grid. drag into available yellow spaces, and passengers into blue seats)");
                penaltyItemNames = new string[] { "None" };
                break;
        }
    }

    void Update()
    {
        pointsTextComponent.text = "Points: " +  GameScript.TotalPoints().ToString();
    }

    public void SetPointsGlobal()
    {
        Globals.points += GameScript.TotalPoints();
    }

    public void finishButtonSFX()
    {
        //audioManager.Play2DSFX(audioManager.buttonFinished);
        return;
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
