using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

}
