using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScenesTransition.Instance.GoToMap();
        }
    }
}
