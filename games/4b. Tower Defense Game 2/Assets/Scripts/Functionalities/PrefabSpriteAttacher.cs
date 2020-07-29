using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpriteAttacher : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private GameObject prefabInstance;
    private bool isAttached;

    Vector3 mousePosition;

    public void AttachSprite()
    {
        isAttached = true;
    }

    public void DrawSpriteAtMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // not smooth
        if (prefabInstance!=null)
        {
            //Debug.Log("Attaching sprite at " + mousePosition);
            prefabInstance.transform.position = mousePosition;
        } else
        {
            prefabInstance = Instantiate(prefab, mousePosition, Quaternion.identity);
            prefabInstance.transform.position = mousePosition;
        }
        
    }

    void FixedUpdate()
    {
        if (isAttached) DrawSpriteAtMousePosition();
    }

    // Update is called once per frame
    void Update()
    {
        // right click to disable
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DisableAttachment();
        }
    }

    public void DisableAttachment()
    {
        isAttached = false;
        if (prefabInstance != null)
        {
            Destroy(prefabInstance);
        }

        Debug.Log("Attachment disabled.");
    }
}
