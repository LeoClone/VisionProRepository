using UnityEngine;
using UnityEngine.UI; // Include the UI namespace to work with UI elements.

public class ToggleGameObjects : MonoBehaviour
{
    // Arrays to hold the GameObjects you want to enable/disable.
    public GameObject[] gameObjectsToEnable;
    public GameObject[] gameObjectsToDisable;

    // Reference to the button that will control the toggling.
    public Button toggleButton;

    private void Start()
    {
        // Add a listener to the button so that it calls the ToggleObjects method when clicked.
        toggleButton.onClick.AddListener(ToggleObjects);
    }

    private void ToggleObjects()
    {
        // Enable all game objects in the enable array.
        foreach (GameObject obj in gameObjectsToEnable)
        {
            obj.SetActive(true);
        }

        // Disable all game objects in the disable array.
        foreach (GameObject obj in gameObjectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}
