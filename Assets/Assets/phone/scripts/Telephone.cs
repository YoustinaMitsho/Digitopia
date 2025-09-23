using UnityEngine;
using DialogueEditor;

public class telephone : MonoBehaviour
{
    bool IsRinging = true;
    [SerializeField] NPCConversation WasnotRinging;
    [SerializeField] NPCConversation WasRinging;
    void Update()
    {
        if (IsRinging)
        {
            if (Time.time > 60f)
            {
                IsRinging = false;
                Debug.Log("not ringing");
            }
            Debug.Log("is ringing");
        }
        else
        {
            Debug.Log("not ringing");
        }
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
        Debug.Log("ringing");
    }
    public void RingingFalse()
    {
        IsRinging = false;
        Debug.Log("not ringing");

    }   
     
}
