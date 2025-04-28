using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes

public class SceneTransition : MonoBehaviour
{
    public float interactionRange = 2f; // How close the player must be
    public KeyCode interactionKey = KeyCode.E; // Default key is E
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) <= interactionRange)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Optional: Draw the interaction range in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
