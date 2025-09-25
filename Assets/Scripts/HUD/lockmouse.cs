using Unity.VisualScripting;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{ 
    public void Enable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Disable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

