using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://answers.unity.com/questions/1009968/how-to-move-a-player-automatically-through-a-list.html
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private List<Vector3> path;

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
                Debug.Log("Moving towards " + waypoint + " from " + transform.position);
                var test = Vector3.MoveTowards(transform.position, waypoint, moveSpeed * Time.deltaTime);
                Debug.Log(moveSpeed * Time.deltaTime);
                transform.position = test;
                
                yield return null;
            }
        }
        // TODO: call damage church thing here + destroy gameobject
    }

    
}
