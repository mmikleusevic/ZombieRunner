using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] InputAction _fire;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] GameObject _hitVFX;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType _ammoType;
    [SerializeField] float _weaponCooldownTimer = 0.2f;
    [SerializeField] TextMeshProUGUI _ammoText;

    bool _canShoot = true;

    private void Update()
    {
        DisplayAmmo();
        bool isPressed = _fire.ReadValue<float>() > 0.5;

        if (isPressed && _canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        _ammoText.text = (_ammoType + ": " + _ammoSlot.GetCurrentAmmo(_ammoType)).ToString();  
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;

        if (_ammoSlot.GetCurrentAmmo(_ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ReduceAmmo();
        }

        yield return new WaitForSeconds(_weaponCooldownTimer);

        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, _range))
        {
            ProccessHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;

            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void ReduceAmmo()
    {
        _ammoSlot.ReduceCurrentAmmo(_ammoType);
    }

    private void ProccessHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(_hitVFX, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 0.1f);
    }

    void OnEnable()
    {
        _fire.Enable();
        _canShoot = true;
    }

    void OnDisable()
    {
        _fire.Disable();
    }
}
