using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butcher : VendorBase
{
    public override void Interact()
    {
        interactableRole = "Butcher";
        interactableName = "Donald";
        base.Interact();
    }
}
