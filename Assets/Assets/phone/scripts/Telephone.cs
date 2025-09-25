using UnityEngine;
using DialogueEditor;
using UnityEngine.InputSystem;


public class Telephone : MonoBehaviour
{
    float ringtime;
    bool IsRinging;
    bool InHand;
    bool lastState; 
    [SerializeField] Transform player;

    [SerializeField] NPCConversation WasnotRinging;
    [SerializeField] NPCConversation WasRinging;
    [SerializeField] Vector3 puttingPhoneOffset;
    [SerializeField] InputAction PressX;
    [SerializeField] AudioSource Ringtonei7;
    Vector3 Playerposition;

    void OnEnable()
    {
        RingingTrue();
        ringtime = Time.time + Random.Range(20f, 61f);
        PressX.Enable();

    }
    void OnDisable()
    {
        RingingFalse();

    }
    void Update()
    {
        IfRinging();
        PutThePhone();
        ringtone();
        Playerposition = player.transform.position + puttingPhoneOffset;
    }
    public void CallorPick()
    {
        if (IsRinging)
        {
            ConversationManager.Instance.StartConversation(WasRinging);
        }
        else
        {
            ConversationManager.Instance.StartConversation(WasnotRinging);
        }
        transform.localScale = new Vector3(0, 0, 0);
        InHand = true;


    }
    public void RingingTrue()
    {
        IsRinging = true;
    }
    public void RingingFalse()
    {
        IsRinging = false;
    }
    void IfRinging()
    {
        if (IsRinging)
        {
            Debug.Log("is ringing");
            if (Time.time > ringtime)
            {
                RingingFalse();
            }
        }
        else
        {
            Debug.Log("not ringing");
        }
    }
    void PutThePhone()
    {

        if (InHand)
        {
            if (PressX.IsPressed())
            {
                transform.position = Playerposition;
                InHand = false;
                transform.localScale = new Vector3(1, 1, 1);

            }
            Debug.Log("phone in hand");
        }
        else
        {
            Debug.Log("phone not in hand");
        }
    }
    void ringtone()
    {
        if (IsRinging && !lastState)
        {
            Ringtonei7.Play();
        }
        else if (!IsRinging && lastState)
        {
            Ringtonei7.Stop();
        }
        lastState = IsRinging;
    }
}
