using UnityEngine;

public class BagItems : MonoBehaviour
{
    [SerializeField]private int id;
    
    public int GetId()
    {
        return id;
    }

    public (Vector3 position, Quaternion rotation) GetTransformationAndRotation()
    {
        return (transform.position, transform.rotation);
    }

    /* void Update()
    {
        // Example of how to use the GetTransformationAndRotation method
        var (position, rotation) = GetTransformationAndRotation();
        Debug.Log($"{name} is located at {position}, and has the rotation {rotation.eulerAngles}");
    } */
}