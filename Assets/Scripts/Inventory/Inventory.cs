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
    public List<Item> items = new List<Item>();
    public void addItem(Item itemPickUp)
    {
        Item copyItem = Instantiate(itemPickUp);
        //search for all itemStack
        foreach (Item item in items)
        {
            //itemStack item name match item pick up name & amount of item Stack is 64 or below
            if (item.name.Equals(itemPickUp.name) && item.amount < item.maxStack)
            {
                item.amount += 1; 
                if (onItemChangedCallBack != null)
                    onItemChangedCallBack.Invoke();
                return;
            }
        }
        //else create new itemStack with that item and amount 1
        items.Add(copyItem);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
    public void remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
