using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : VendorBase
{
    public override void Interact()
    {
        interactableRole = "Blacksmith";
        interactableName = "Tony";
        base.Interact();
    }
}
