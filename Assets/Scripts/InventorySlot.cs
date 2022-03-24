using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    ItemStack itemStack;
    public Text text;
    public Button removeButton;

    public void AddItem(ItemStack newItemStack)
    {
        itemStack = newItemStack;

        //set the icon within the slot to show the item icon
        icon.sprite = itemStack.item.icon;
        icon.enabled = true;

        //enable remove button
        removeButton.interactable = true;

        //show amount of item up to 64
        text.text = itemStack.amount.ToString();
        text.enabled = true;
    }

    public void ClearSlot()
    {
        itemStack = null;

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
        Inventory.instance.remove(itemStack);
    }

    public void UseItem()
    {
        if  (itemStack != null)
        {
            itemStack.item.Use();
        }
    }
}
