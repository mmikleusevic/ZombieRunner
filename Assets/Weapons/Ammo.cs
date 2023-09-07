using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int _ammoAmount = 10;
    [SerializeField] int _ammoSet = 10;

    public int GetCurrentAmmo()
    {
        return _ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        _ammoAmount--;
    }
}
