using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHitBackController : UnitController
{
    public bool agroed;

    public override void Update()
    {
        attackTimer += Time.deltaTime;
        if (currentTarget != null)
        {
            navAgent.destination = currentTarget.position;
            //Debug.Log(currentTarget.GetComponent<UnitController>().Health);
            var distance = (this.transform.position - currentTarget.position).magnitude;
            //Debug.Log(distance);
            if (distance <= unitStats.attackRange)
            {
                Attack();
            }
            agroed = true;
        }
        else if (agroed)
        {
            
            currentTarget = FindObjectsOfType<PlayerUnitController>()[0].transform;
        }
    }

    public override void TakeDamage(UnitController enemy, float damage)
    {
        if(currentTarget==null)
        {
            currentTarget = enemy.GetComponent<Transform>();
        }
        

        Health -= damage;
        
        if (Health <= 0)
        {
            Die();
        }
        StartCoroutine(Flasher(StartCol));
    }
}
