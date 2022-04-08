using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Equipment[] currentEquipment;
    public delegate void OnEquipmentChanged();
    public OnEquipmentChanged onEquipmentChangedCallBack;
    public Equipment headDefault, bodyDefault, meleeDefault, rangeDefault;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentEnum)).Length;
        currentEquipment = new Equipment[numSlots];
        Equip(headDefault);
        Equip(bodyDefault);
        Equip(meleeDefault);
        Equip(rangeDefault);
        onEquipmentChangedCallBack.Invoke();
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentEnum;

        currentEquipment[slotIndex] = newEquipment;

        if (onEquipmentChangedCallBack != null) onEquipmentChangedCallBack.Invoke();

    }
}
