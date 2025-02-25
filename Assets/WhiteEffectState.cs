using UnityEngine;

public class WhiteEffectState : StateMachineBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform objTransform;
    private Color originalColor;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform = animator.transform;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            spriteRenderer.material = new Material(Shader.Find("Sprites/Default"));
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (objTransform != null)
        {
            originalScale = objTransform.localScale;
            originalRotation = objTransform.rotation;

            objTransform.localScale = originalScale * 0.5f;
            objTransform.rotation = Quaternion.identity;
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
            objTransform.rotation = originalRotation;
        }
    }
}
