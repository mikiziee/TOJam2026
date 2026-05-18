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
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = true;
            onLidFull.Invoke();
        }
    }
    
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = true;
            onLidFull.Invoke();
        }
    }
    
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("BackpackItem"))
        {
            isFull = false;
            onLidNotFull.Invoke();
        }
    }

    public bool GetIsFull()
    {
        return isFull;
    }
    
}
