using StarterAssets;
using System.Collections;
using System.Collections.Generic;
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
        GetComponent<FirstPersonController>().enabled = false;

        _gameOverCanvas.enabled = true;

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
