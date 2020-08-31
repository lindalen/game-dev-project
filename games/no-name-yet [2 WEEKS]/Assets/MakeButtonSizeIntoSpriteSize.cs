using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButtonSizeIntoSpriteSize : MonoBehaviour
{
    private Button attachedButton;
    private Sprite attachedSprite;

    void Awake()
    {
        //attachedButton = GetComponent<Button>();
        //attachedSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Start()
    {
        //ChangeButtonSize();
    }

    private void ChangeButtonSize()
    {
        attachedButton.image.rectTransform.sizeDelta = attachedSprite.rect.size;
    }
}
