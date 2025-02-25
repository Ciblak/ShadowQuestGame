using UnityEngine;

public class RotateOnSlash2 : StateMachineBehaviour
{
    private Quaternion originalRotation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform objTransform = animator.gameObject.transform;
        originalRotation = objTransform.rotation;
        objTransform.rotation = Quaternion.Euler(0, 0, -45);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.rotation = originalRotation;
    }
}
