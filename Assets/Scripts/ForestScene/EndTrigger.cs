using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Test");
            Globals.nextScene = "DayCounterCutscene";
            Globals.currentDay++;
            animator.Play("FadeIN");
        }
    }
}
