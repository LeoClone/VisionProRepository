using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using PolySpatial.Samples;

public class SplineButtonScript : HubButton
{
    SplineScript splineScript;

    [SerializeField] string[] splineNames;

    public enum ButtonType
    {
        ToggleInput,
        ToggleAll,
        AllOff,
        AllOn
    }

    [SerializeField]
    private ButtonType dropdownChoice;

    private float cooldownDuration = 0.1f;

    private float lastPressTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject topParent = GetTopParent(gameObject);

        splineScript = topParent.GetComponent<SplineScript>();

        lastPressTime = -cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Press()
    {
        base.Press();

        if (Time.time - lastPressTime < cooldownDuration)
        {
            return; 
        }

        lastPressTime = Time.time;

        if (splineScript == null)
            return;

        switch (dropdownChoice)
        {
            case ButtonType.ToggleInput:

                foreach (string spline in splineNames)
                {
                    splineScript.ToggleSpline(spline);
                }

                break;
            case ButtonType.ToggleAll:

                splineScript.ToggleAllSplines();

                break;
            case ButtonType.AllOff:

                splineScript.ToggleAllSplines(false);

                break;
            case ButtonType.AllOn:

                splineScript.ToggleAllSplines(true);

                break;
            default:
                Debug.Log("Unknown option selected");
                break;
        }
    }

    GameObject GetTopParent(GameObject obj)
    {
        // Keep traversing up the hierarchy until there is no parent
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
        }
        return obj;
    }
}
