using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroAnimator : MonoBehaviour
{
    [SerializeField] GameObject backgroundPanel;
    [SerializeField] Text introText;

    [SerializeField] float TimeToWaitBeforeFadingBackground;

    private Image panelImage;

    private void Awake()
    {
        panelImage = backgroundPanel.GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(FadeTextToZeroAlpha(1f, introText));
        StartCoroutine(FadeImageToZeroAlpha(1f, panelImage));
    }


    private IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeImageToZeroAlpha(float t, Image i)
    {
        yield return new WaitForSeconds(TimeToWaitBeforeFadingBackground);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
