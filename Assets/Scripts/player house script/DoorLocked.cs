using UnityEngine;

public class DoorLocked : MonoBehaviour
{
    void OnEnable()
    {
        lockTheDoor();
    }
    public void lockTheDoor()
    {
        GetComponent<Interactable>().enabled = false;
        GetComponent<Outline>().enabled = false;
        Debug.Log("door is locked");
    }
    public void UnlockTheDoor()
    {
        GetComponent<Interactable>().enabled = true;
        GetComponent<Outline>().enabled = true;      
        Debug.Log("door is not locked"); 
    }
}
