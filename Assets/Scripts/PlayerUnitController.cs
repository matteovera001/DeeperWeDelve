using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitController : UnitController
{
    int index;
    public characterStats character;
    characterUI myUI;

    public void bondUI (characterUI charUI)
    {
        myUI = charUI;
    }

    public override void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        attackTimer = unitStats.attackSpeed;
        rtsGM = FindObjectOfType<RTSGameManager>();
        
    }

    public override void Update()
    {

        //Need to change out with state machine functionality.
        attackTimer += Time.deltaTime;
        if (currentTarget != null)
        {


            navAgent.destination = currentTarget.position;
            var distance = (this.transform.position - currentTarget.position).magnitude;
            if (distance <= unitStats.attackRange)
            {
                if (currentTarget.tag == "EnemyUnit")
                {
                    Attack();
                }
                else
                {
                    DoAction();
                }

            }


        }
    }


    //OLD
    public void GenerateStats(characterStats characterInput, Color col)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = col;
        Debug.Log("My name is" +characterInput.name);
        character = characterInput;

        MaxHealth = (character.constitution * unitStats.health)/10;
        Health = MaxHealth;
        StartCol = GetComponent<Renderer>().material.color;
        AttackSpeed = unitStats.attackSpeed / (10 / character.dextarity );
        Damage = (character.strength*unitStats.attackDamage) / 10;



        
    }

    

    public void DoAction()
    {
        currentTarget.GetComponent<Yarn.Unity.ActionToDialogue>().onAction(this.GetComponent<Collider>());
        currentTarget = null;
    }

    public override void TakeDamage(UnitController enemy, float damage)
    {
        if (currentTarget == null)
        {
            if (enemy!=null)
            {
                currentTarget = enemy.GetComponent<Transform>();
            }
            
        }
        Debug.Log("take dAMAGE");

        

        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
        StartCoroutine(Flasher(StartCol));
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
        StartCoroutine(Flasher(StartCol));
    }


    public override void Die()
    {
        Debug.Log("DO DEATH STUFF:");
        Destroy(this.gameObject);

        /*
        PlayerManager pm = FindObjectOfType<PlayerManager>();
        pm.selectedUnits.Remove(this);
        CharacterGen cg = FindObjectOfType<CharacterGen>();


        cg.party.Remove(character);

        Debug.Log("Party Members Left: " + cg.party.Count);
        
        myUI.Death();

        */
        //Death stuff;
    }
}
