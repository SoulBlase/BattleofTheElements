using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehavior : StateMachineBehaviour
{
    public FighterStates behaviorState;

    public float horizontalForce;
    public float verticalForce;

    protected Player1Controller fighter;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entered State: " + animator.name);
        if(fighter == null)
        {
            fighter = animator.gameObject.GetComponentInParent<Player1Controller>();
            Debug.Log(fighter.name);
        }

        fighter.currentState = behaviorState;
        fighter.body.AddRelativeForce(new Vector3(0, verticalForce, 0));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter.body.AddRelativeForce(new Vector3(0, 0, horizontalForce));
    }


}
