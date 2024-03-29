using UnityEngine;

public class PlayerEquipment : Singleton<PlayerEquipment>
{
    public InventorySO DaggerSO;
    public InventorySO SwordSO;
    public InventorySO HelmetSO;
    public GameObject dagger;
    public GameObject sword;
    public GameObject helmet;

    public void AddDagger()
    {
        if(!DaggerSO.isUsed)
        {
            sword.SetActive(false);
            dagger.SetActive(true);
            DaggerSO.isUsed = true;
        }
        else
        {
            dagger.SetActive(false);
            DaggerSO.isUsed = false;
        }
    }

    public void AddSword()
    {
        if(!SwordSO.isUsed)
        {
            dagger.SetActive(false);
            sword.SetActive(true);
            SwordSO.isUsed = true;
        }
        else
        {
            sword.SetActive(false);
            SwordSO.isUsed = false;
        }
    }

    public void AddHelmet()
    {
        if(!HelmetSO.isUsed)
        {
            helmet.SetActive(true);
            HelmetSO.isUsed = true;
        }
        else
        {
            helmet.SetActive(false);
            HelmetSO.isUsed = false;
        }
    }
}
