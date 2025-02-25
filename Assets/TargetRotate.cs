using UnityEngine;

public class TargetRotate : StateMachineBehaviour
{
    public float rotationSpeed = 100f;
    private Transform objTransform;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform = animator.gameObject.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (objTransform != null)
        {
            objTransform.Rotate(Vector3.forward, +rotationSpeed * Time.deltaTime);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objTransform.rotation = Quaternion.identity;
    }
}