using UnityEngine;

using UnityEngine.Events;

public class Lid : MonoBehaviour
{
    private bool isFull = false;
    
    public UnityEvent onLidFull;
    public UnityEvent onLidNotFull;

    public void ontriggerenter2D(Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = true;
            Debug.Log("Lid is now full!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = true;
            Debug.Log("Lid is now full!");
            onLidFull.Invoke();
        }
    }
    
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = true;
            Debug.Log("A collider is inside the lid!");
            onLidFull.Invoke();
        }
    }
    
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = false;
            Debug.Log("A collider has exited the lid!");
            onLidNotFull.Invoke();
        }
    }

    public bool GetIsFull()
    {
        return isFull;
    }
    
}
