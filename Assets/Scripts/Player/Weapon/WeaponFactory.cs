using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    public enum SlotType
    {
        Primary,
        Secondary
    }

    public List<Weapon> weapons;
    private Dictionary<SlotType, Weapon> _currentWeapons = new Dictionary<SlotType, Weapon>();

    private void Start()
    {
        // Assuming the first primary and secondary weapon appearances are the default starting weapons
        EquipWeapon(0, SlotType.Primary);
        EquipWeapon(1, SlotType.Secondary);
    }

    public void EquipWeapon(int slotIndex, SlotType slotType)
    {
        if (slotIndex < 0 || slotIndex >= weapons.Count)
        {
            Debug.LogError($"Invalid {slotType.ToString().ToLower()} weapon slot index.");
            return;
        }

        Weapon weapon = GetWeapon(slotType);
        
        if (weapon == null)
        {
            Debug.LogError("Invalid slot type.");
            return;
        }
        
        weapon = weapons[slotIndex];
        
        if (weapon != null)
        {
            SetCurrentWeapon(slotType, weapon);
        }
        else
        {
            Debug.LogError($"Invalid {slotType.ToString().ToLower()} weapon slot configuration.");
        }
    }
    
    public void UseWeapon(SlotType slotType, bool canShoot)
    {
        Weapon currentWeapon = GetCurrentWeapon(slotType);
        if (currentWeapon != null)
        {
            currentWeapon.Fire(canShoot);
        }
    }
    
    private Weapon GetWeapon(SlotType slotType)
    {
        return weapons.Find(appearance => appearance.slotType == slotType);
    }
    
    private Weapon GetCurrentWeapon(SlotType slotType)
    {
        if (_currentWeapons.TryGetValue(slotType, out Weapon currentWeapon))
        {
            return currentWeapon;
        }

        return null;
    }
    
    private void SetCurrentWeapon(SlotType slotType, Weapon weapon)
    {
        _currentWeapons[slotType] = weapon;
    }
}