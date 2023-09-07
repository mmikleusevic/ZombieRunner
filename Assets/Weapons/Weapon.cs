using System.Collections;
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

    float _weaponCooldownTimer = COOLDOWN_TIME;

    static float COOLDOWN_TIME = 0.1f;

    private void Update()
    {
        bool isPressed = _fire.ReadValue<float>() > 0.5 ;

        if (isPressed && _weaponCooldownTimer <= 0 && _ammoSlot.GetCurrentAmmo() > 0)
        {
            Shoot();
        }

        _weaponCooldownTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ReduceAmmo();
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        _weaponCooldownTimer = COOLDOWN_TIME;

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
        _ammoSlot.ReduceCurrentAmmo();
    }

    private void ProccessHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(_hitVFX, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 0.1f);
    }

    void OnEnable()
    {
        _fire.Enable();
    }

    void OnDisable()
    {
        _fire.Disable();
    }
}
