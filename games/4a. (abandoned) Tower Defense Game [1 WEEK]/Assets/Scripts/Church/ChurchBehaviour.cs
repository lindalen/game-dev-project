using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchBehaviour : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage; //temp 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnemyReached()
    {
        health -= damage;
    }
}
