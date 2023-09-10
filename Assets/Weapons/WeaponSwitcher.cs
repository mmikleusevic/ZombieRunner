using StarterAssets;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int _currentWeapon = 0;
    StarterAssetsInputs _input;
    float _switchTimeout = 0.33f;

    private event Action ListenToInput;

    private void OnEnable()
    {
        ListenToInput += ProcessKeyInput;
        ListenToInput += ProcessScrollWheel;
    }

    private void OnDestroy()
    {
        ListenToInput -= ProcessKeyInput;
        ListenToInput -= ProcessScrollWheel;
    }

    private void Start()
    {
        FirstPersonController fpController = FindFirstObjectByType<FirstPersonController>();
        _input = fpController.GetComponent<StarterAssetsInputs>();
        Task.WhenAll(SetWeaponActive());
    }

    private void Update()
    {
        int previousWeapon = _currentWeapon;

        ListenToInput?.Invoke();

        if (previousWeapon != _currentWeapon)
        {
            Task.WhenAll(SetWeaponActive());
        }
    }

    private void ProcessKeyInput()
    {
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
        else if (_input.scroll == -120)
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

    private async Task SetWeaponActive()
    {
        int weaponIndex = 0;

        await Awaitable.WaitForSecondsAsync(_switchTimeout, destroyCancellationToken);

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeapon)
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
