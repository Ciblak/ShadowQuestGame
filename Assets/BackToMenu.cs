using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    public void LoadMainMenu()
    {
        DestroyPersistentObjects();
        SceneManager.LoadScene("MainMenu");
        }

    private void DestroyPersistentObjects()
    {
    GameObject[] persistentObjects = GameObject.FindGameObjectsWithTag("Persistent");
        foreach (var obj in persistentObjects)
        {
            Destroy(obj);
        }
    }
}