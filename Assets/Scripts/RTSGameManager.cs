using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSGameManager : MonoBehaviour
{
    public void UnitTakeDamage(UnitController attackingController, UnitController attackedController)
    {
        var damage = attackedController.Damage;

        attackedController.TakeDamage(attackingController, damage);
    }
}
