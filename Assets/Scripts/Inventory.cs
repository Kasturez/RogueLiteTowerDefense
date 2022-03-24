using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than 1 instance of inventory, something is not working properly");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public List<ItemStack> itemStacks = new List<ItemStack>();
    public void addItem(Item itemPickUp)
    {
        //search for all itemStack
        foreach (ItemStack itemStack in itemStacks)
        {
            //itemStack item name match item pick up name & amount of item Stack is 64 or below
            if (itemStack.item.name.Equals(itemPickUp.name) && itemStack.amount < 65)
            {
                itemStack.amount += 1;
                if (onItemChangedCallBack != null)
                    onItemChangedCallBack.Invoke();
                return;
            }
        }
        //else create new itemStack with that item and amount 1
        itemStacks.Add(new ItemStack(itemPickUp));

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
    public void remove(ItemStack itemStack)
    {
        itemStacks.Remove(itemStack);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
