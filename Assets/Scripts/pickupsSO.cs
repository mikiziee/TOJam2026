using UnityEngine;

public class pickupsSO : MonoBehaviour
{
    public string pickupName;
    public int itemCode;

    public string GetName()
    {
        return this.pickupName;
    }

    public int GetItemCode()
    {
        return this.itemCode;
    }
}
