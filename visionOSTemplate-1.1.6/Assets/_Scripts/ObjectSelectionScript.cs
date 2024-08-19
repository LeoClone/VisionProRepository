using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject[] _uiObjects;

    [SerializeField] GameObject initialUI;

    [SerializeField] GameObject[] jetAnimObjects;

    bool isBukitAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBukitAnimating)
        {
            objects[1].transform.Rotate(Vector3.up);
        }
    }

    public void SelectObject(int id)
    {
        initialUI.SetActive(false);

        objects[id].SetActive(true);
        _uiObjects[id].SetActive(true);
    }

    public void QuitObject()
    {
        initialUI.SetActive(true);

        foreach (GameObject item in objects)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in _uiObjects)
        {
            item.SetActive(false);
        }

        isBukitAnimating = false;
    }

    public void AnimateJet()
    {
        foreach (GameObject item in jetAnimObjects)
        {
            item.SetActive(!item.activeSelf);
        }
    }

    public void AnimateBukit()
    {
        isBukitAnimating = !isBukitAnimating;
    }


}
