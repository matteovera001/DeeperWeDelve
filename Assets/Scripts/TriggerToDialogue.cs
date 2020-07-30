using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    public class TriggerToDialogue : HasDialogueAssoc
    {

        

        //public string characterName = "";

        public List<UnitController> pack;
        public bool cleared = false;
        public bool triggered = false;
        public bool seeded = false;


        public void FixedUpdate()
        {
            pack.RemoveAll(x => x == null);
            //Debug.Log(pack[0] == null);
            //Debug.Log("CAAAAT");

            if (pack.Count == 0 && !cleared)
            {
                cleared = true;

                /*
                CharacterGen charGen = FindObjectOfType<CharacterGen>();


                charGen.KillPack();

    */
                Debug.Log("cleared");

            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            pack.RemoveAll(x => x == null);
            //Debug.Log(pack[0] == null);
            //Debug.Log("CAAAAT");

            if (pack.Count == 0 && !cleared)
            {
                cleared = true;

                /*
                CharacterGen charGen = FindObjectOfType<CharacterGen>();
                charGen.KillPack();
                
                */
                Debug.Log("cleared");

            }

            if (!seeded)
            {
                seed = Random.Range(0, talkToNode.Count);
                seeded = true;

            }
            if (other.CompareTag("PlayerUnit") && triggered == false)
            {
                
                col = other;
                OpenDialogue();
                triggered = true;
                InMemoryVariableStorage imvs = FindObjectOfType<InMemoryVariableStorage>();
                imvs.setCharValues(col.GetComponent<PlayerUnitController>().character);
            }
        }

        

        public override void Aggro()
        {
            foreach (var unit in pack)
            {
                unit.SetNewTarget(col.transform);
            }
        }

        public GameObject whatIdestroy;
        public override void DestroyOb()
        {
            //whatIdestroy.SetActive(false);
        }

    }
}