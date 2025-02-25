using UnityEngine;

public class RotateAndScaleState : StateMachineBehaviour
{
    private Transform objTransform;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform = animator.transform;

        if (objTransform != null)
        {
            originalScale = objTransform.localScale;
            originalRotation = objTransform.rotation;

            objTransform.Rotate(0, 0, -90);
            objTransform.localScale *= 3f;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (objTransform != null)
        {
            objTransform.localScale = originalScale;
            objTransform.rotation = originalRotation;
        }
    }
}
