using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttacker : MonoBehaviour
{
    public void AttackObject(GameObject go, float damage)
    {
        go.SendMessage("OnAttacked", damage); // assumes object implements OnAttacked event/method
    }

    public void AttackObjects(List<GameObject> gos, float damage)
    {
        foreach(GameObject go in gos)
        {
            go.SendMessage("OnAttacked", damage);
        }
    }
}
