using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStare : StateMachineBehaviour
{
    private Animator _ani;
    private GameObject _stareObject;

    [SerializeField]
    private float waitTime;

    private float _currentTimeLeft;

    private bool _actionLock = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.GetComponent<PlayerSphereCast>().OnSphereCastHitEvent +=
            SwitchState;

        _ani = animator;
        _stareObject = _ani.GetComponent<Blackboard>().At<GameObject>("stare-obj");

        _currentTimeLeft = waitTime;

        Debug.Log("Stare State");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<PlayerSphereCast>().OnSphereCastHitEvent -=
            SwitchState;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        _currentTimeLeft -= Time.deltaTime;

        if (_currentTimeLeft <= 0f)
        {
            _actionLock = true;

            Debug.Log("Action");
            Stareable s;
            if (s = _stareObject.GetComponent<Stareable>())
            {
                s.BeginStare();
            }

            _actionLock = false;
        }
    }

    private void SwitchState(RaycastHit hit)
    {
        if (_actionLock) return;

        if (hit.collider != null)
        {
            if (!ReferenceEquals(_stareObject, hit.collider.gameObject))
            {
                _ani.SetBool("stare", false);

                Stareable s;
                if (s = _stareObject.GetComponent<Stareable>())
                {
                    s.EndStare();
                }
            }
        }
        else
        {
            _ani.SetBool("stare", false);

            Stareable s;
            if (s = _stareObject.GetComponent<Stareable>())
            {
                s.EndStare();
            }
        }
    }
}
