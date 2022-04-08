using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    //inventory content
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] inventorySlots;

    //equipment content
    public Transform equipmentSlotParent;
    EquipmentManager equipmentManager;
    InventorySlot[] equipmentSlots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();

        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChangedCallBack += UpdateEquipment;

        equipmentSlots = equipmentSlotParent.GetComponentsInChildren<InventorySlot>();
        equipmentManager.onEquipmentChangedCallBack.Invoke();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }

    void UpdateEquipment()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (i < equipmentManager.currentEquipment.Length)
            {
                if(equipmentManager.currentEquipment[i] == null) continue;
                equipmentSlots[i].AddItem(equipmentManager.currentEquipment[i]);
            }
            else { 
                equipmentSlots[i].ClearSlot();
            }
        }
    }
}
