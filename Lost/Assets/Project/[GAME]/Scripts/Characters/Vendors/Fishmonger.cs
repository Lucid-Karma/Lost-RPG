using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishmonger : VendorBase
{
    public override void Interact()
    {
        interactableRole = "Piscatrix";
        interactableName = "Diana";
        base.Interact();
    }
}
