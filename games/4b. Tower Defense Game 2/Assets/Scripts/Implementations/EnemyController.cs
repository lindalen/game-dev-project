using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float hp;
    [SerializeField] private float damage;

    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
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
        ResourceController church = GameObject.FindGameObjectWithTag("Church").GetComponent<ResourceController>();
        church.SendMessage("OnEnemyKill");
        Destroy(gameObject);
    }
}
