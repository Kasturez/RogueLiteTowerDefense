using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void MouseEnterInteract()
    {
        base.MouseEnterInteract();
        PickUp();
    }
    //destroy gameobject and access the inventory to add the item in
    void PickUp()
    {
        Inventory.instance.addItem(item);
        Destroy(gameObject);
    }
}
