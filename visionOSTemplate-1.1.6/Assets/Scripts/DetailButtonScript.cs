using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DetailButtonScript : MonoBehaviour
{
    Button myButton;

    DetailsNavigationScript navigationScript = null;

    public string imageName;
    public string videoName;
    public string description;

    NavigationVideoScript navigationVideoScript = null;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();

        //Debug.Log(myButton);

        myButton.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick()
    {
        //Debug.Log("ASDASDA");
        // Look for a parent with the DetailsNavigationScript component
        if(navigationScript == null)
        {
            navigationScript = FindParentWithDetailsNavigationScript(this.transform);
        }

        if (navigationScript != null)
        {
            Debug.Log("Found parent with DetailsNavigationScript!");
            // Perform actions with navigationScript as needed
        }
        else
        {
            Debug.LogWarning("No parent with DetailsNavigationScript found.");
            return;
        }

        navigationScript.imageName = imageName;
        navigationScript.videoName = videoName;
        navigationScript.description = description;

        navigationScript.OpenDetail();

        if (navigationVideoScript == null)
        {
            navigationVideoScript = FindParentWithNavigationVideoScriptt(this.transform);
        }

        if (navigationVideoScript != null)
        {
            Debug.Log("Found parent with navigationVideoScript!");
            // Perform actions with navigationScript as needed
        }
        else
        {
            Debug.LogWarning("No parent with navigationVideoScript found.");
            return;
        }

        navigationVideoScript.videoName = videoName;
    }

    DetailsNavigationScript FindParentWithDetailsNavigationScript(Transform currentTransform)
    {
        Transform parentTransform = currentTransform.parent;

        while (parentTransform != null)
        {
            DetailsNavigationScript component = parentTransform.GetComponent<DetailsNavigationScript>();
            if (component != null)
            {
                return component; // Return the found component
            }
            parentTransform = parentTransform.parent; // Move up to the next parent
        }

        return null; // Return null if no parent with the specified component is found
    }

    NavigationVideoScript FindParentWithNavigationVideoScriptt(Transform currentTransform)
    {
        Transform parentTransform = currentTransform.parent;

        while (parentTransform != null)
        {
            NavigationVideoScript component = parentTransform.GetComponent<NavigationVideoScript>();
            if (component != null)
            {
                return component; // Return the found component
            }
            parentTransform = parentTransform.parent; // Move up to the next parent
        }

        return null; // Return null if no parent with the specified component is found
    }
}
