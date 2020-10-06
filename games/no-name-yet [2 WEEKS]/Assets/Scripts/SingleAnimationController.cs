using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAnimationController : MonoBehaviour
{
    [SerializeField] Animation animationToPlay;

    public void Play()
    {
        animationToPlay.Play();
    }
}
