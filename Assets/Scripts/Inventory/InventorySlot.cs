using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Text text;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;

        //set the icon within the slot to show the item icon
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.SetNativeSize();

        //enable remove button
        removeButton.interactable = true;

        //show amount of item up to 64
        text.text = item.amount.ToString();
        text.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        //clear item sprite, make the slot clear
        icon.sprite = null;
        icon.enabled = false;

        //make the button uninteractable
        removeButton.interactable = false;

        //set amount of item shown in the UI to disable
        text.enabled = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.remove(item);
    }

    public void UseItem()
    {
        if  (item != null)
        {
            item.Use();
        }
    }
}
