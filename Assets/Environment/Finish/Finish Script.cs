using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SceneLoader>().ReloadGame();
    }
}
