using UnityEngine;
using System.Collections;

public class ActivateGameObjects : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Array of GameObjects to be activated

    // Method to start the activation process
    public void ActivateObjects()
    {
        StartCoroutine(ActivateObjectsAfterDelay(4)); // 3 seconds delay
    }

    private IEnumerator ActivateObjectsAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate each GameObject in the array
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
