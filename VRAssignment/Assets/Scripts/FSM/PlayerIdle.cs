using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : StateMachineBehaviour
{
    private Animator _ani;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.GetComponent<PlayerSphereCast>().OnSphereCastHitEvent +=
            SwitchState;

        _ani = animator;

        Debug.Log("Idle State");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<PlayerSphereCast>().OnSphereCastHitEvent -=
            SwitchState;
    }

    private void SwitchState(RaycastHit hit)
    {
        if (hit.collider != null)
        {
            _ani.GetComponent<Blackboard>().Insert("stare-obj", hit.collider.gameObject);

            _ani.SetBool("stare", true);
        }
    }
}
