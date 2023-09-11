using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    static string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER))
        {
            FlashlightSystem flashlight = other.GetComponentInChildren<FlashlightSystem>();

            if (flashlight == null) return;

            flashlight.RestoreLightAngle();
            flashlight.RestoreLightIntensity();

            Destroy(gameObject);
        }
    }
}
