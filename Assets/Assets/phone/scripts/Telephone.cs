using UnityEngine;
using DialogueEditor;

public class Telephone : MonoBehaviour
{
    float ringtime;
    bool IsRinging;

    [SerializeField] NPCConversation WasnotRinging;
    [SerializeField] NPCConversation WasRinging;
    void OnEnable()
    {
        RingingTrue();
        ringtime = Time.time + Random.Range(20f, 61f);

    }
    void OnDisable()
    {
        RingingFalse();

    }
    void Update()
    {
        IfRinging();
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
}
