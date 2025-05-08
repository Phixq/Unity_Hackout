using UnityEngine;
using UnityEngine.UI;

public class HideUIImageOnKey : MonoBehaviour
{
    public Transform player;
    public Transform targetObject;
    public float interactionRange = 3f;
    public Image uiImage;

    void Update()
    {
        if (player == null || targetObject == null || uiImage == null) return;

        float distance = Vector3.Distance(player.position, targetObject.position);

        if (distance <= interactionRange && Input.GetKeyDown(KeyCode.E))
        {
            uiImage.gameObject.SetActive(false);
        }
    }

    // Draw interaction range in the Scene view
    void OnDrawGizmos()
    {
        if (targetObject == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(targetObject.position, interactionRange);
    }
}
