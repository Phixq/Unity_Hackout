using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    private Queue<string> objectives = new Queue<string>();

    void Start()
    {
        // Add objectives to the queue
        objectives.Enqueue("Escape The Prison.");
        objectives.Enqueue("Find A Key To Unlock Door.");
        objectives.Enqueue("Defeat the boss.");

        UpdateObjective();
    }

    public void CompleteObjective()
    {
        if (objectives.Count > 0)
        {
            objectives.Dequeue(); // Remove completed objective
            UpdateObjective();
        }
    }

    void UpdateObjective()
    {
        if (objectives.Count > 0)
        {
            objectiveText.text = "Objective: " + objectives.Peek(); // Show next objective
        }
        else
        {
            objectiveText.text = "All objectives complete!";
        }
    }
}
