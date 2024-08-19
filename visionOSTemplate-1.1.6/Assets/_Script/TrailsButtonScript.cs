using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TrailsButtonScript : MonoBehaviour
{
    TrailsControlScript trailsScript;

    [SerializeField] string[] trailNames;

    private Button myButton;

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

        trailsScript = topParent.transform.Find("BukitTimahNature Trails_V4").GetComponent<TrailsControlScript>();

        lastPressTime = -cooldownDuration;

        myButton = GetComponent<Button>();

        // Add a listener to the onClick event of the Button component
        myButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClick()
    {

        if (Time.time - lastPressTime < cooldownDuration)
        {
            return;
        }

        lastPressTime = Time.time;

        if (trailsScript == null)
            return;

        switch (dropdownChoice)
        {
            case ButtonType.ToggleInput:

                foreach (string trail in trailNames)
                {
                    trailsScript.ToggleTrail(trail);
                    //Debug.Log(trail);
                }

                break;
            case ButtonType.ToggleAll:

                trailsScript.ToggleAllTrails();

                break;
            case ButtonType.AllOff:

                trailsScript.ToggleAllTrails(false);

                break;
            case ButtonType.AllOn:

                trailsScript.ToggleAllTrails(true);

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
