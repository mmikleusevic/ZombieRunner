using StarterAssets;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas _gameOverCanvas;

    private void Start()
    {
        _gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GetComponent<FirstPersonController>().ResetSettings();
        GetComponentInChildren<WeaponSwitcher>().enabled = false;
        _gameOverCanvas.enabled = true;

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
