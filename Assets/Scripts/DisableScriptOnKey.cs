using UnityEngine;

public class DisableScriptOnKey : MonoBehaviour
{
    public GameObject targetObject; // The GameObject that holds the script you want to disable
    public MonoBehaviour scriptToDisable; // Drag the script itself here
    public float interactionRange = 2f; // How close you have to be
    public KeyCode interactionKey = KeyCode.E; // Default is E

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
                if (targetObject != null && scriptToDisable != null)
                {
                    scriptToDisable.enabled = false;
                    Debug.Log("Script disabled!");
                }
            }
        }
    }

    // This will show a circle in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
