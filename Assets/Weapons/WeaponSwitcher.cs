using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int _currentWeapon = 0;
    StarterAssetsInputs _input;

    float _changeWeaponTime = 0.5f;

    private void Start()
    {
        FirstPersonController fpController = FindObjectOfType<FirstPersonController>();
        _input = fpController.GetComponent<StarterAssetsInputs>();
        SetWeaponActive();
    }

    private void Update()
    {
        int previousWeapon = _currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        Debug.Log(_input.changeWeaponThree);
        if (_input.changeWeaponOne)
        {
            _currentWeapon = 0;
            _input.changeWeaponOne = false;
        }
        else if (_input.changeWeaponTwo)
        {
            _currentWeapon = 1;
            _input.changeWeaponTwo = false;
        }
        else if (_input.changeWeaponThree)
        {
            _currentWeapon = 2;
            _input.changeWeaponThree = false;
        }
    }

    private void ProcessScrollWheel()
    {
        if (_input.scroll == 120)
        {
            if (_currentWeapon >= transform.childCount - 1)
            {
                _currentWeapon = 0;
            }
            else
            {
                _currentWeapon++;
            }
        }
        else if(_input.scroll == -120)
        {
            if (_currentWeapon <= 0)
            {
                _currentWeapon = transform.childCount - 1;
            }
            else
            {
                _currentWeapon--;
            }
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIndex == _currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }
}
