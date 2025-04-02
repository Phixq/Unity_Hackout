using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Assign in the Inspector

    void Start()
    {
        UpdateObjective("Escape The Prison."); // Initial objective
    }

    public void UpdateObjective(string newObjective)
    {
        objectiveText.text = "Objective: " + newObjective;
    }
}
