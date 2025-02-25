using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitToDesktop()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}