using UnityEngine;
using Yarn.Unity;
using System.Collections;
using System.Collections.Generic;

public class YarnCommands : MonoBehaviour
{
    [SerializeField] DialogueRunner dr;
    [SerializeField] InputHandler player;

    public void OnEnable()
    {
        dr.AddCommandHandler(
            "disable_dialogue",     // the name of the command
            DisableDialogueCanvas // the method to run
        );
    }

    public void DisableDialogueCanvas()
    {
        player.ChangePlayerToIdle();
        gameObject.SetActive(false);
    }

}
