using UnityEngine;
using UnityEngine.UI; // Needed for UI Text
using TMPro; // Needed if you're using TextMeshPro

public class ObjectiveUpdater : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Drag your Objective Text UI here
    public string newObjective = "Reach the next checkpoint!"; // What the objective updates to

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectiveText != null)
            {
                objectiveText.text = newObjective;
            }
            Destroy(gameObject); // Optional: destroy this trigger after it updates
        }
    }
}
