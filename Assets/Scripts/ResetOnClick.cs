using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOnClick : MonoBehaviour
{
    // The object you're looking for to trigger the reset
    public GameObject targetObject;

    // The distance at which the player can interact with the object
    public float interactionDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the player and the target object
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);

        // If the player is within the specified distance and presses the "E" key
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            ResetScene();
        }
    }

    // Reset the scene
    void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
