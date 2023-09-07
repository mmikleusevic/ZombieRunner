using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int _ammoAmount = 5;
    [SerializeField] AmmoType _ammoType;

    static string PLAYER = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER))
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmount);
            Destroy(gameObject);
        }
    }
}
