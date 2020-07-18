using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] public GameObject towerPrefab;

    [SerializeField] private Sprite validPositionSprite;
    [SerializeField] private Sprite invalidPositionSprite;

    private float towerSize;

    private bool isPlacing;
    private bool isPositionValid;
    private GameObject spritePrefab;
    private SpriteRenderer sr;

    private Vector3 currentMousePosition;
    //TODO: can only be placed if fundings >= tower cost
    private void Awake()
    {
        towerSize = towerPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        isPlacing = false;
        Debug.Log("TowerSize is " + towerSize);
    }
    // Start is called before the first frame update
    void Start()
    {
        spritePrefab = GetGameObjectSprite();
        sr = spritePrefab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*isPositionValid = IsPositionValid(currentMousePosition, towerSize * 5);

        if (isPlacing)
        {
            if (isPositionValid)
            {
                sr.sprite = validPositionSprite;
            } else
            {
                sr.sprite = invalidPositionSprite;
            }
            AttachSpriteToMouse(spritePrefab, currentMousePosition);
            if (Input.GetKeyDown(KeyCode.Mouse0) && isPositionValid)
            {
                Debug.Log("Tower placed.");
                StopPlacing();
                //destroy temp gameobject
            }
            else
            {
                Debug.Log("Tower not placed.");
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopPlacing();
        }
        /*if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isPlacing)
            {

            }
            // (if current position is valid) place prefab, call method that withdraws funds, stop placing
        }*/ 
    }

    public void StartPlacing()
    {
        if (isPlacing == false) isPlacing = true;
    }

    private void StopPlacing()
    {
        isPlacing = false;
    }



    private void AttachSpriteToMouse(GameObject g, Vector3 mousePosition)
    {
        float moveSpeed = 0.1f;
        g.transform.position = Vector2.Lerp(g.transform.position, mousePosition, moveSpeed);
    }

    private bool IsPositionValid(Vector3 v, float towerSize)
    {
        Collider[] hitColliders = Physics.OverlapSphere(v, towerSize, LayerMask.GetMask("Path"));
        if (hitColliders.Length == 0) Debug.Log("No path detected!");
        Debug.Log(1<<12);
        return hitColliders.Length > 0;
    }

    private GameObject GetGameObjectSprite()
    {
        GameObject g = new GameObject("TowerSprite");
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();
        s.sprite = invalidPositionSprite;

        return g;
    }
}
