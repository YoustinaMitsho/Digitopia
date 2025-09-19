using Unity.VisualScripting;
using UnityEngine;

public class SitAction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform player;
    [SerializeField] GameObject targetPos;
    [SerializeField] Transform targetLook;
    [SerializeField] FirstPersonMovement movementScript;
    [SerializeField] Jump jumpScript;

    [Header("Heights")]
    [SerializeField] float standHeight = 1.8f;
    [SerializeField] float sitHeight = 1.6f;

    [Header("Smoothness")]
    [SerializeField] float smoothSpeed = 5f;

    [Header("Settings")]
    [SerializeField] bool hideTarget;
    private bool isSitting;
    private Vector3 initialPos;

    float targetHeight;
    private void Start()
    {
        isSitting = false;
    }

    void Update()
    {
        targetHeight = isSitting ? sitHeight : standHeight;
        Vector3 targetPos = new Vector3(
            playerCamera.localPosition.x,
            targetHeight,
            playerCamera.localPosition.z
        );

        playerCamera.localPosition = Vector3.Lerp(
            playerCamera.localPosition,
            targetPos,
            Time.deltaTime * smoothSpeed
        );
    }

    public void TakeAction()
    {
        if(!isSitting)
        {
            SitDown();
        }
        else
        {
            StandUp();
        }

    }

    void SitDown()
    {
        initialPos = player.transform.position;

        if (hideTarget) targetPos.SetActive(false);

        /*player.transform.position = Vector3.Lerp(
                player.transform.position,
                targetPos.transform.position,
                Time.deltaTime * smoothSpeed
            );

        Vector3 dir = (targetLook.position - player.transform.position).normalized;
        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            player.transform.rotation = Quaternion.Slerp(
                player.transform.rotation,
                targetRotation,
                Time.deltaTime * smoothSpeed
            );
        }*/
        player.transform.position = targetPos.transform.position;
        Vector3 dir = (targetLook.position - player.transform.position).normalized;
        if (dir != Vector3.zero)
        {
            player.transform.rotation = Quaternion.LookRotation(dir);
        }
        if (movementScript) movementScript.enabled = false;
        if (jumpScript) jumpScript.enabled = false;
        isSitting = true;
    }

    void StandUp()
    {
        if (hideTarget) targetPos.SetActive(true);
        /*player.transform.position = Vector3.Lerp(
                player.transform.position,
                initialPos,
                Time.deltaTime * smoothSpeed
            );*/
        player.transform.position = initialPos;

        if (movementScript) movementScript.enabled = true;
        if (jumpScript) jumpScript.enabled = true;
        isSitting = false;
    }
}
