using UnityEngine;

public class Lid : MonoBehaviour
{
    private bool isFull = false;

    public void ontriggerenter2D(Collider2D other)
    {
        if (other.CompareTag("Trinket"))
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
        }
    }
    
    void OnTriggerStay2D (Collider2D other)
    {
        isFull = true;
        Debug.Log ("A collider is inside the lid");
    }
    
    void OnTriggerExit2D (Collider2D other)
    {
        isFull = false;
        Debug.Log ("A collider has exited the lid");
    }

    public bool GetIsFull()
    {
        return isFull;
    }
    
}
