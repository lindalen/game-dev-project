using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
    public void DoCoroutine(Animator animator, float seconds)
    {
        StartCoroutine(DamageAfterSeconds(animator, seconds));
    }
    public IEnumerator DamageAfterSeconds(Animator animator, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.gameObject.SendMessage("Damage");
    }
}
