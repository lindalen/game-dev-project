using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject path;
    [SerializeField] private float moveSpeed;

    private Transform[] waypoints;
    
    private EnemyController controller;


    void Awake()
    {
        controller = GetComponent<EnemyController>();
        waypoints = path.GetComponent<Path>().GetWaypoints();
        Debug.Log("Waypoints are null: " + waypoints == null);
        transform.position = waypoints[0].position;
    }

    private void Start()
    {
        MoveAlongPath();
    }

    public void MoveAlongPath()
    {
        StartCoroutine(MovementCoroutine());
    }

    private IEnumerator MovementCoroutine()
    {
        for (int i = 0; i<waypoints.Length; i++)
        {
            Vector3 currentWaypoint = waypoints[i].position;
            //TODO: Add death check
            while (Vector3.Distance(transform.position, currentWaypoint) > .01f)
            {
                Debug.Log(transform.position.z + " " + currentWaypoint.z);
                var test = Vector3.MoveTowards(transform.position, currentWaypoint, moveSpeed * Time.deltaTime);
                //test.z = 0; // for some reason it goes to -19
                transform.position = test;
                RotateTowardsWaypoint(currentWaypoint);
                yield return null;
            }
        }

        OnChurchReached();
    }

    // yanked from last tower defense game, sue me
    private void RotateTowardsWaypoint(Vector3 waypoint)
    {
        Vector3 relativePos = waypoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        rotation.x = transform.rotation.x;
        rotation.y = transform.rotation.y;
        transform.rotation = rotation;
    }

    private void OnChurchReached()
    {
        ResourceController church = GameObject.FindGameObjectWithTag("Church").GetComponent<ResourceController>();
        church.SendMessage("LoseHealth", controller.Damage);
        Destroy(gameObject);
    }

    
}
