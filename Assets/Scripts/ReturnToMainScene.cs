using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainScene : MonoBehaviour
{
    [SerializeField] private float timeBeforeReturn = 20f; // Time in seconds before returning

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeforeReturn)
        {
            SceneManager.LoadScene(0); // Load scene with index 0
        }
    }
}
