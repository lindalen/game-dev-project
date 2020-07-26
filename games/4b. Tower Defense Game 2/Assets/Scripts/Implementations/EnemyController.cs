using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float hp;

    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public void OnAttacked(float damage)
    {
        hp -= damage;
        //Debug.Log("Enemy hp: " + hp);
        DeathCheck();
    }

    public void DeathCheck()
    {
        if (hp > 0) return;
        Destroy(gameObject);
    }
}
