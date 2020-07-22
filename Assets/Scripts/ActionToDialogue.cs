using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yarn.Unity
{
    public class ActionToDialogue : HasDialogueAssoc
    {
        public List<UnitController> pack;
        
        public bool triggered = false;
        public bool seeded = false;
        public void onAction(Collider other)
        {
            //Debug.Log("action");
            if (other.CompareTag("PlayerUnit") && triggered == false)
            {
                if (!seeded)
                {
                    seed = Random.Range(0, talkToNode.Count);
                    seeded = true;

                }
                col = other;
                OpenDialogue();

                //triggered = true;
                InMemoryVariableStorage imvs = FindObjectOfType<InMemoryVariableStorage>();
                imvs.setCharValues(col.GetComponent<PlayerUnitController>().character);
            }
        }

        public override void Aggro()
        {
            triggered = true;
            foreach (var unit in pack)
            {
                unit.SetNewTarget(col.transform);
            }
        }

        public GameObject whatIdestroy;
        public override void DestroyOb()
        {
            triggered = true;
            whatIdestroy.SetActive(false);
        }
    }
}

