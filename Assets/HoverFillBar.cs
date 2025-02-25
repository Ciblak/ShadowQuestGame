using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class HoverFillBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image barImage;
    public float fillSpeed = 3f;

    private Coroutine fillRoutine;

    private void Start()
    {
        if (barImage == null)
            barImage = GetComponent<Image>();

        barImage.fillAmount = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (fillRoutine != null) StopCoroutine(fillRoutine);
        fillRoutine = StartCoroutine(FillBar(1f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (fillRoutine != null) StopCoroutine(fillRoutine);
        fillRoutine = StartCoroutine(FillBar(0f));
    }

    private IEnumerator FillBar(float targetFill)
    {
        while (!Mathf.Approximately(barImage.fillAmount, targetFill))
        {
            barImage.fillAmount = Mathf.MoveTowards(barImage.fillAmount, targetFill, fillSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
