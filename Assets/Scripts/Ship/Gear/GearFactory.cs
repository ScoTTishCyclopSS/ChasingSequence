using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public enum GearSlot
{
    Primary,
    Secondary,
    AttackAbility,
    DefenceAbility
}

public class GearFactory : MonoBehaviour
{
    public Transform primaryGearContainer;
    public Transform secondaryGearContainer;
    public GameObject attackAbilityGearContainer;
    public GameObject defenceAbilityGearContainer;
    
    private List<GameObject> _primaryGear = new List<GameObject>();
    private List<GameObject> _secondaryGear = new List<GameObject>();
    private List<GameObject> _attackAbilityGear = new List<GameObject>();
    private List<GameObject> _defenceAbilityGear = new List<GameObject>();
    
    public event Action<GearSlot> OnGearChanged;

    private Dictionary<GearSlot, GameObject> _slots = new SerializableDictionary<GearSlot, GameObject>();

    private void Start()
    {
        _primaryGear = FillGearList(primaryGearContainer);
        _secondaryGear = FillGearList(secondaryGearContainer);
        
        Debug.Log(_primaryGear.Count);
        
        SetPrimary(0);
        SetSecondary(0);
    }

    private List<GameObject> FillGearList(Transform container)
    {
        List<GameObject> result = container.GetComponentsInChildren<Transform>(true)
            .Where(t => t != container)
            .Select(t => t.gameObject)
            .ToList();
        return result;
    }

    public Gear GetGear(GearSlot slot)
    {
        GameObject gear;
        if (!_slots.TryGetValue(slot, out gear))
            throw new InvalidOperationException($"No weapon defined for slot {slot}");

        return gear.GetComponent<Gear>();
    }


    public void SetPrimary(int idx)
    {
        SetGearToSlot(GearSlot.Primary, idx);
        OnGearChanged?.Invoke(GearSlot.Primary);
    }
    
    public void SetSecondary(int idx)
    {
        SetGearToSlot(GearSlot.Secondary, idx);
        OnGearChanged?.Invoke(GearSlot.Secondary);
    }
    

    private void SetGearToSlot(GearSlot slot, int idx)
    {
        GameObject gear;
        if (_slots.TryGetValue(slot, out gear))
        {
            _slots[slot].SetActive(false);
        }
        GameObject gearSelected;
        
        switch (slot)
        {
            case GearSlot.Primary:
                gearSelected = _primaryGear[idx];
                break;
            case GearSlot.Secondary:
                gearSelected = _secondaryGear[idx];
                break;
            case GearSlot.AttackAbility:
                gearSelected = _attackAbilityGear[idx];
                break;
            case GearSlot.DefenceAbility:
                gearSelected = _defenceAbilityGear[idx];
                break;
            default:
                gearSelected = _slots[slot];
                break;
        }

        _slots[slot] = gearSelected;
        _slots[slot].SetActive(true);
    }
}