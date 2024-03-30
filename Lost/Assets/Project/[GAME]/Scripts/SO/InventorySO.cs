using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "InventorySO", menuName = "Lost Crown/InventorySO", order = 0)]
public class InventorySO : ItemSO 
{
    public int itemSalePrice;
    public string type;
    public bool isUsed = false;
}
