using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindFirstObjectByType<SceneLoader>().ReloadGame();
    }
}
