using UnityEngine;

public class rotatt : StateMachineBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform objTransform;
    private Color originalColor = Color.white;
    private Vector3 originalScale;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform = animator.transform;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            spriteRenderer.color = new Color(0f, 0f, 0f, 0.5f);
        }

        if (objTransform != null)
        {
            originalScale = objTransform.localScale;
            objTransform.localScale = originalScale * 0.75f;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }

        if (objTransform != null)
        {
            objTransform.localScale = originalScale;
        }
    }
}
