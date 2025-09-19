using UnityEditor.SearchService;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    bool clicked = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && clicked)
        {
            Debug.Log("Go to Map");
            clicked = false;
            ScenesManager.Instance.GoToMap();
        }
    }

    public void TakeAction()
    {
        if (!clicked)
        {
            clicked = true;
            Debug.Log("Clicked");
        }
    }
}
