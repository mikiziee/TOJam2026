using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TMP_Text finalScoreTextComponent;

     void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalScoreTextComponent.text = "Final Score: " + Globals.points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
