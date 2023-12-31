using System;
using System.Linq;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] _ammoSlot;

    [Serializable]
    private class AmmoSlot
    {
        public AmmoType _ammoType = 0;
        public int _ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = _ammoSlot.FirstOrDefault(a => a._ammoType == ammoType);

        if (ammoSlot == null) return 0;

        return ammoSlot._ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = _ammoSlot.FirstOrDefault(a => a._ammoType == ammoType);

        if (ammoSlot == null) return;

        ammoSlot._ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        AmmoSlot ammoSlot = _ammoSlot.FirstOrDefault(a => a._ammoType == ammoType);

        if (ammoSlot == null) return;

        ammoSlot._ammoAmount += ammoAmount;
    }
}
