using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookseller : VendorBase
{
    public override void Interact()
    {
        interactableRole = "Bookseller";
        interactableName = "Laura";
        base.Interact();
    }
}
