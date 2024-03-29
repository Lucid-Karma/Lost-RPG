using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCountTextController : MonoBehaviour
{
    private TextMeshProUGUI itemText;
    public TextMeshProUGUI ItemText
    {
        get
        {
            if(itemText == null)
            itemText = GetComponent<TextMeshProUGUI>();

            return itemText;
        }
    }

    public int Count = 0;
    public void UpdateItemText()
    {
        Count = ItemManager.Instance.InventoryItemCount;
        ItemText.text = "" + Count;
    }

    public void HideItemText()
    {
        ItemText.text = null;
    }
}
