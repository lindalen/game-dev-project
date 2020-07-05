using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAfterAnimation : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CoroutineHelper>().DoCoroutine(animator, stateInfo.length);
    }
}

