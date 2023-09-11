using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float _lightDecay = .1f;
    [SerializeField] float _angleDecay = 0.5f;
    [SerializeField] float _minimumAngle = 20f;
    [SerializeField] float _startingIntensity = 10f;
    [SerializeField] float _startingAngle = 35f;

    Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle()
    {
        _light.innerSpotAngle = _startingAngle;
    }

    public void RestoreLightIntensity()
    {
        _light.intensity = _startingIntensity;
    }

    private void DecreaseLightIntensity()
    {
        _light.intensity -= _lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (_light.innerSpotAngle <= _minimumAngle) return;

        _light.innerSpotAngle -= _angleDecay * Time.deltaTime;
    }
}
