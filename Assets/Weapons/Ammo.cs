using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] _ammoSlot;

    [Serializable]
    private class AmmoSlot
    {
        public AmmoType _ammoType;
        public int _ammoAmount;
    }

    public int GetCurrentAmmo()
    {
        //return _ammoAmount;
        return 10;
    }

    public void ReduceCurrentAmmo()
    {
        //_ammoAmount--;
    }
}
