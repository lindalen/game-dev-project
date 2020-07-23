using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInRadiusFinder : MonoBehaviour
{
    [SerializeField] private string searchTag;
    [SerializeField] private float radius;

    private Vector3 center;
    CircleCollider2D col;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();

        center = transform.position; //assumes that the gameobject is static
        radius = col.radius; //assumes two things; 1. tower has a collider, 2. the collider corresponds to attack range
        Debug.Log("Radius: " + radius);
        Debug.Log("Center: " + center);
    }
    public List<GameObject> GetEnemiesInRange()
    {
        Collider2D[] collidersInRange = GetCollidersInRange();
        if (collidersInRange.Length < 1) return null;

        List<GameObject> enemies = new List<GameObject>();

        foreach (Collider2D col in collidersInRange)
        {
            Debug.Log("Tag of found collider: " + col.gameObject.tag);
            if (col.gameObject.tag == searchTag)
            {
                enemies.Add(col.gameObject);
                Debug.Log("Enemy found and added.");
            }
        }
        return enemies;
    }

    private Collider2D[] GetCollidersInRange()
    {
        return Physics2D.OverlapCircleAll(center, radius);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetEnemiesInRange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
