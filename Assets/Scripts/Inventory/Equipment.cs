using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentEnum equipmentEnum;

    public int armorModifier;
    public int damageModifier;
    public int durability;

    public override void Use()
    {
        base.Use();
        //equip item, remove item from inventory
        EquipmentManager.instance.Equip(this);
    }
}
public enum EquipmentEnum{Head,Body,Melee,Range}