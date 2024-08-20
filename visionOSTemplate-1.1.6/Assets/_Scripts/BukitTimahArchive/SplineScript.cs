using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using samples.Runtime;
using UnityEngine.Splines;

public class SplineScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSpline("Spline_005");
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleAllSplines();
        }
        */
    }

    // Input the name of the spline/trail to toggle its activeness
    public void ToggleSpline(string splineName)
    {
        AnimateSplineExtrude spline = transform.Find(splineName).GetComponent<AnimateSplineExtrude>();

        SplineExtrude splineExtrude = transform.Find(splineName).GetComponent<SplineExtrude>();

        splineExtrude.Radius = spline.m_Speed == .0001f ? 0.002f : 0;
        spline.m_Speed = spline.m_Speed == .0001f ? 0.27f : .0001f;
    }

    public void ToggleSpline(string splineName, bool turnOn)
    {
        AnimateSplineExtrude spline = transform.Find(splineName).GetComponent<AnimateSplineExtrude>();

        SplineExtrude splineExtrude = transform.Find(splineName).GetComponent<SplineExtrude>();

        splineExtrude.Radius = turnOn ? 0.002f : 0;
        spline.m_Speed = turnOn ? 0.27f : .0001f;
    }

    // Assign the trail tag to all trail/splines in game object for this to work
    public void ToggleAllSplines()
    {
        foreach (GameObject spline in GameObject.FindGameObjectsWithTag("Trail"))
        {
            ToggleSpline(spline.name);
        }
    }

    public void ToggleAllSplines(bool turnOn)
    {
        foreach (GameObject spline in GameObject.FindGameObjectsWithTag("Trail"))
        {
            ToggleSpline(spline.name, turnOn);
        }
    }
}
