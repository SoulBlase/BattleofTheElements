using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehavior : StateMachineBehaviour
{
    public FighterStates behaviorState;

    public float horizontalForce;
    public float verticalForce;

    protected Player1Controller fighter;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entered State: " + animator.name);
        if(fighter == null)
        {
            fighter = animator.gameObject.GetComponentInParent<Player1Controller>();
            //Debug.Log(fighter.name);
        }

        fighter.currentState = behaviorState;
        //fighter.body.AddRelativeForce(new Vector3(0, verticalForce, 0));
        Debug.Log("Does the vertical force code work?");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //fighter.body.AddRelativeForce(new Vector3(0, 0, horizontalForce));
        Debug.Log("Does the horizontal force code work?");
    }


}
