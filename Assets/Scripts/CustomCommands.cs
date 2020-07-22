using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    public class CustomCommands : MonoBehaviour
    {

        // Drag and drop your Dialogue Runner into this variable.
        public DialogueRunner dialogueRunner;
        public HasDialogueAssoc HDA;

        public void Awake()
        {

            // Create a new command called 'aggro', which looks at a target.
            dialogueRunner.AddCommandHandler(
                "Aggro",     // the name of the command
                Aggro // the method to run
            );
            dialogueRunner.AddCommandHandler(
                "DestroyOb",     // the name of the command
                DestroyOb // the method to run
            );
            dialogueRunner.AddCommandHandler(
                "HurtPlayer",     // the name of the command
                HurtPlayer // the method to run
            );
            dialogueRunner.AddCommandHandler(
                "ReturnSurface",     // the name of the command
                ReturnSurface // the method to run
            );
        }

        // The method that gets called when '<<camera_look>>' is run.
        private void Aggro(string[] parameters)
        {
            HDA.Aggro();
        }

        private void DestroyOb(string[] parameters)
        {
            HDA.DestroyOb();
        }

        private void HurtPlayer(string[] parameters)
        {
            HDA.HurtPlayer();
            //HDA.col.GetComponent<PlayerUnitController>().TakeDamage(, 15);
        }

        private void ReturnSurface(string[] parameters)
        {
            CharacterGen charGen = FindObjectOfType<CharacterGen>();
            charGen.ReturnSurface();
        }
    }

}
