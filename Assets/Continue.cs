using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{

    public void ContinueEndless()
    {
        GameManager.Instance.FadeScene("Transition");
    }


}