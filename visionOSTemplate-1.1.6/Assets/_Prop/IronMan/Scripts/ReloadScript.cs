using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{
    [SerializeField] GameObject[] _uiToReload;
    Vector3[] _uiInitialTransform;
    Quaternion[] _uiInitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;

        _uiInitialTransform = new Vector3[_uiToReload.Length];
        _uiInitialRotation = new Quaternion[_uiToReload.Length];

        foreach (GameObject ui in _uiToReload)
        {
            _uiInitialTransform[index] = ui.transform.position;
            _uiInitialRotation[index] = ui.transform.rotation;
            index += 1;
            //print(index);
        }
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadUI()
    {
        int index = 0;
        foreach(GameObject ui in _uiToReload)
        {
            
            ui.SetActive(true);

            ui.transform.position = _uiInitialTransform[index];
            ui.transform.rotation = _uiInitialRotation[index];

            Image barImage = ui.GetComponent<Image>();
            BoxCollider barCollider = ui.GetComponent<BoxCollider>();

            barImage.enabled = false;
            barCollider.enabled = false;

            Transform[] children = ui.GetComponentsInChildren<Transform>(true);

            GameObject closeBar = FindChildByName(ui, "GrabberX");
            Image closeImage = closeBar.GetComponent<Image>();
            BoxCollider closeCollider = closeBar.GetComponent<BoxCollider>();

            closeImage.enabled = false;
            closeCollider.enabled = false;

            index += 1;
        }
    }

    GameObject FindChildByName(GameObject parent, string name)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in children)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
