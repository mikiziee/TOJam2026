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
            if (Globals.currentDay == 5)
            {
                Globals.nextScene = "EndCutscene";
            }
            else
            {
                Globals.nextScene = "CarScene";
            }
            animator.Play("FadeIN");
        }
    }
}
