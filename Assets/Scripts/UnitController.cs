using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    public NavMeshAgent navAgent;

    public Transform currentTarget;
    public RTSGameManager rtsGM;
    public UnitStats unitStats;
    public float attackTimer;
    public float Health;
    public float MaxHealth;
    public Color StartCol;
    public float AttackSpeed;
    public float Damage;

    public virtual void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        attackTimer = unitStats.attackSpeed;
        rtsGM = FindObjectOfType<RTSGameManager>();
        MaxHealth = unitStats.health;
        Health = MaxHealth;
        StartCol = GetComponent<Renderer>().material.color;
        AttackSpeed = unitStats.attackSpeed;
        Damage = unitStats.attackDamage;
    }

    public virtual void Update()
    {
        //Should switch to State machine behavior.



        attackTimer += Time.deltaTime;
        if (currentTarget!=null)
        {
            navAgent.destination = currentTarget.position;
            Debug.Log(currentTarget.GetComponent<UnitController>().Health);
            var distance = (this.transform.position - currentTarget.position).magnitude;
            Debug.Log(distance);
            if(distance<=unitStats.attackRange)
            {
                Attack();
            }
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        navAgent.destination = dest;
    }

    public void SetSelected(bool isSelected)
    {
        transform.Find("Highlight").gameObject.SetActive(isSelected);
    }

    public void SetNewTarget(Transform enemy)
    {
        currentTarget = enemy;
    }

    public void Attack()
    {
        if(attackTimer>=unitStats.attackSpeed)
        {
            rtsGM.UnitTakeDamage(this, currentTarget.GetComponent<UnitController>());
            attackTimer = 0;
        }
        
    }

    virtual public void TakeDamage(UnitController enemy, float damage)
    {
        Health -= damage;
        if (Health<=0)
        {
            Die();
        }
        StartCoroutine(Flasher(StartCol));
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
        //Death stuff;
    }

    public IEnumerator Flasher(Color DefaultColor)
    {
        var renderer = GetComponent<Renderer>();
        for (int i = 0; i < 2; i++)
        {
            renderer.material.color = Color.grey;
            yield return new WaitForSeconds(0.05f);
            renderer.material.color = DefaultColor;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
