using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InBed : MonoBehaviour
{
    bool OnBed;
    bool skip;
    Vector3 SleeptargetPosition = new Vector3(23.806f, 1.4f, -6.686f);
    Quaternion SleeptargetRotation = Quaternion.Euler(0f, 0f, 90f);
    Vector3 AwaketargetPosition = new Vector3(23.993f, 0.562f, -5.607f);
    Quaternion AwaketargetRotation = Quaternion.Euler(0f, -90f, 0f);
    [SerializeField] InputAction PressX;


    void Update()
    {
        if (PressX.IsPressed())
        {
            Debug.Log("x is pressed");
            StandFromBed();
        }
    }
    void OnEnable()
    {
        gameObject.tag = "bed";
        PressX.Enable();
    }
    public void takeAction()
    {
        
            if (OnBed)
            {
                StandFromBed();
            }
            else
            {
                SetOnBed();
            }
    }
    void SetOnBed()
    {
        OnBed = true;
        Debug.Log("you are in bed");
        transform.SetPositionAndRotation(SleeptargetPosition, SleeptargetRotation);
        LockMovement();
    }
    void StandFromBed()
    {
        OnBed = false;
        Debug.Log("you are not in bed");
        transform.SetPositionAndRotation(AwaketargetPosition, AwaketargetRotation);
        UnlockMovement();
    }
    void LockMovement()
    {
        GetComponent<FirstPersonMovement>().enabled = false;
        GetComponent<Crouch>().enabled = false;
        GetComponent<Jump>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponentInChildren<FirstPersonLook>().enabled = false;
    }
    void UnlockMovement()
    {
        GetComponent<FirstPersonMovement>().enabled = true;
        GetComponent<Crouch>().enabled = true;
        GetComponent<Jump>().enabled = true;
        GetComponentInChildren<FirstPersonLook>().enabled = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None
                                              | RigidbodyConstraints.FreezeRotationX
                                              | RigidbodyConstraints.FreezeRotationZ;
    }
}
