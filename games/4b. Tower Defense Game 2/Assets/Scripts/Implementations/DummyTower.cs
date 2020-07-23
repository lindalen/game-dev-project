using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : MonoBehaviour, IAttacker
{
    [SerializeField] private float damage;
    [SerializeField] private float attacksPerSecond;
    [SerializeField] private float attackRadius;

    [SerializeField] private ObjectInRadiusFinder finder;
    [SerializeField] private ObjectAttacker attacker;
    [SerializeField] private CircleCollider2D col;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float AttacksPerSecond
    {
        get { return attacksPerSecond; }
        set { attacksPerSecond = value; }
    }
    public float AttackRadius
    {
        get { return attackRadius; }
        set { attackRadius = value; }
    }

    public ObjectInRadiusFinder Finder
    {
        get { return finder; }
        set { finder = value; }
    }

    public ObjectAttacker Attacker
    {
        get { return attacker; }
        set { attacker = value; }
    }

    private void Awake()
    {
        // Caching components
        finder = GetComponent<ObjectInRadiusFinder>();
        attacker = GetComponent<ObjectAttacker>();
        col = GetComponent<CircleCollider2D>();

        // Initialization
        col.radius = attackRadius;
    }

    private void Start()
    {
        InvokeRepeating("DamageEnemies", 0, 1f/attacksPerSecond);
    }

    public void DamageEnemies()
    {
        List<GameObject> enemiesInRange = finder.GetEnemiesInRange();
        if (enemiesInRange.Count < 1) return;
        attacker.AttackObject(enemiesInRange[0], damage);
        Debug.Log("Attack fired.");
    }
}
