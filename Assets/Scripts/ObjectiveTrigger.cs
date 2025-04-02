using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public ObjectiveUI objectiveUI; // Assign the ObjectiveUI script in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag
        {
            objectiveUI.UpdateObjective("Unlock the door!");
            Destroy(gameObject); // Remove the key from the scene
        }
    }
}
