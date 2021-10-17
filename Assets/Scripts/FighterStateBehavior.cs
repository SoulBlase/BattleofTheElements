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
        if(fighter == null)
        {
            fighter = animator.gameObject.GetComponent<Player1Controller>();
            Debug.Log("Object Reference?");
        }

        fighter.currentState = behaviorState;
        fighter.body.AddRelativeForce(new Vector3(0, verticalForce, 0));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter.body.AddRelativeForce(new Vector3(0, 0, horizontalForce));
    }


}
