using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea] public string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(TooltipManager.Instance!=null)TooltipManager.Instance.ShowTooltip(tooltipMessage, Input.mousePosition + new Vector3(10f, -10f, 0f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(TooltipManager.Instance!=null)TooltipManager.Instance.HideTooltip();
    }
}