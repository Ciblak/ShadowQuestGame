using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;
    public GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;
    private RectTransform tooltipRect;
    private Vector3 offset = new Vector3(15f, -15f, 0f);
    public bool tooltipsOn=false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        tooltipRect = tooltipPanel.GetComponent<RectTransform>();
        tooltipPanel.SetActive(false);
    }

    private void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            //Vector3 newPos = Input.mousePosition + offset;
            //tooltipRect.position = ClampToScreen(newPos);
        }
    }

    public void ShowTooltip(string message, Vector3 position)
    {
        if(tooltipsOn){
        tooltipText.text = message;
        tooltipPanel.SetActive(true);
        //tooltipRect.position = ClampToScreen(position + offset);
        }
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }

    public void Idekbro()
    {
        if(tooltipsOn)tooltipsOn=false;
        else tooltipsOn=true;
    }

    private Vector3 ClampToScreen(Vector3 position)
    {
        Vector3 clampedPos = position;
        float panelWidth = tooltipRect.rect.width * tooltipRect.lossyScale.x;
        float panelHeight = tooltipRect.rect.height * tooltipRect.lossyScale.y;

        if (clampedPos.x + panelWidth > Screen.width) clampedPos.x = Screen.width - panelWidth-10f;
        if (clampedPos.y - panelHeight < 0) clampedPos.y = panelHeight+10f;

        return clampedPos;
    }
}
