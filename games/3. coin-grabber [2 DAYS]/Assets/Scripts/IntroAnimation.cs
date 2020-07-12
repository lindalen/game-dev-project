using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.Play("Intro_Fadein");
        StartCoroutine(WaitBeforeFadingOut());
    }
    private IEnumerator WaitBeforeFadingOut()
    {
        yield return new WaitForSeconds(2.5f);
        animator.Play("Intro_Fadeout");
    }
}
