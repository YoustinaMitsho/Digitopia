using Unity.VisualScripting;
using UnityEngine;

public class ScenesTransition : MonoBehaviour
{
    public static ScenesTransition Instance;
    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keeps it alive across scenes
    }

    public void GoToHouse()
    {
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("House");
    }

    public void GoToCoffee()
    {
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Coffee");
    }

    public void GoToMap()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}
