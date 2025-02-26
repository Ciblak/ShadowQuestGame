using UnityEngine;

public class sizer : StateMachineBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform objTransform;
    private Vector3 originalScale;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform = animator.transform;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();

        if (objTransform != null)
        {
            originalScale = objTransform.localScale;
            objTransform.localScale = originalScale * 3f;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (objTransform != null)
        {
            objTransform.localScale = originalScale;
        }
    }
}
