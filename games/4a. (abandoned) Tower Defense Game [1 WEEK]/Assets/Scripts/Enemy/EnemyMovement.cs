using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://answers.unity.com/questions/1009968/how-to-move-a-player-automatically-through-a-list.html
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private List<Vector3> path;


    private EnemyBehaviour enemyBehaviour;

    // Use this for initialization
    public void SetPathAndStartMoving(List<Vector3> path)
    {
        // initialize movepath
        this.path = path;
        MoveAlongPath();
    }
    public void MoveAlongPath()
    {
        StartCoroutine(MovementCoroutine());
    }

    private IEnumerator MovementCoroutine()
    {
        foreach(Vector3 waypoint in path)
        {
            //TODO: Add death check
            while (Vector3.Distance(transform.position, waypoint) > .01f)
            {
                var test = Vector3.MoveTowards(transform.position, waypoint, moveSpeed * Time.deltaTime);
                transform.position = test;
                RotateTowardsWaypoint(waypoint);
                yield return null;
            }
        }
        OnChurchReached(); 
    }

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
        ChurchBehaviour church = GameObject.FindGameObjectWithTag("Church").GetComponent<ChurchBehaviour>();
        church.SendMessage("OnEnemyReached");
        Destroy(gameObject);
    }
}
