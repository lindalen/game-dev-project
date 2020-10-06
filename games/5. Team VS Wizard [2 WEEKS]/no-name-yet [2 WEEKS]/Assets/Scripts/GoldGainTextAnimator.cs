using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldGainTextAnimator : MonoBehaviour
{
    [SerializeField] Text goldGainText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoldGain(float reward)
    {
        goldGainText.text = "+ " + reward;
        ConvertTextToFullAlpha();
        StartCoroutine(FadeTextToZeroAlpha(1f, goldGainText));
    }

    private IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    private void ConvertTextToFullAlpha()
    {
        goldGainText.color = new Color(goldGainText.color.r, goldGainText.color.g, goldGainText.color.b, 1);
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
}
