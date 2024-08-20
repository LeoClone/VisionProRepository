using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUIScript : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] private GameObject activeUI;

    [SerializeField] PolySpatial.Samples.BukitTimahInputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager.recentlySelected = objectToFollow;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (objectToFollow != null)
        {
            Vector3 targetPosition = objectToFollow.transform.position;

            Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y + 0.5f, targetPosition.z);

            transform.position = newPosition;
        }
        */
    }

    public void SwitchObject(GameObject NewObject)
    {
        NewObject.SetActive(true);

        NewObject.transform.position = objectToFollow.transform.position;
        NewObject.transform.rotation = objectToFollow.transform.rotation;
        NewObject.transform.localScale = objectToFollow.transform.localScale;

        objectToFollow.SetActive(false);

        objectToFollow = NewObject;

        inputManager.recentlySelected = NewObject;

        SwitchUI(NewObject.name);
    }

    void SwitchUI(string objectName)
    {
        Debug.Log(objectName);
        GameObject newUI = transform.Find(objectName).gameObject;
        
        if (newUI != null)
        {
            activeUI.SetActive(false);
            newUI.SetActive(true);

            activeUI = newUI;
        }
    }

    public void SetObjectToFollow(GameObject newObject)
    {
        objectToFollow = newObject;
    }
}
