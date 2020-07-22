using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yarn.Unity
{
    public class HasDialogueAssoc : MonoBehaviour
    {
        public List<string> talkToNode = new List<string>();
        public Collider col;
        [Header("Optional")]
        public YarnProgram scriptToLoad;
        public CustomCommands cm;
        public int seed;
        public void Awake()
        {
            if (scriptToLoad != null)
            {
                DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
                cm = FindObjectOfType<CustomCommands>();
                dialogueRunner.Add(scriptToLoad);
                



            }
            seed = Random.Range(0, talkToNode.Count);
        }

        public void OpenDialogue()
        {
            cm.HDA = this;
            FindObjectOfType<DialogueRunner>().StartDialogue(talkToNode[seed]);
        }

        public virtual void Aggro()
        {

        }

        public virtual void DestroyOb()
        {

        }

        public virtual void HurtPlayer()
        {
            col.GetComponentInChildren<PlayerUnitController>().TakeDamage(15f);
        }

    }
}

