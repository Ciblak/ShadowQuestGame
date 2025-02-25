using UnityEngine;
using UnityEngine.UI;

public class ShiningText : MonoBehaviour
{
    private Text textMesh; 
    private float speed = 0.5f;

    void Awake()
    {
        textMesh = GetComponent<Text>();
    }

    void Update()
    {
        float redValue = Mathf.Lerp(100f / 255f, 1f, Mathf.PingPong(Time.time * speed, 1f));
        textMesh.color = new Color(redValue, textMesh.color.g, textMesh.color.b, textMesh.color.a);
    }
}