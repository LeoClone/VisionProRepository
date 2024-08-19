using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using samples.Runtime;
using UnityEngine.Splines;

public class TrailsControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ToggleAllTrails(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTrail(string splineName)
    {
        /*
        GameObject trail = transform.Find(splineName).gameObject;
        trail.SetActive(!trail.activeSelf);
        */

        AnimateSplineExtrude spline = transform.Find(splineName).GetComponent<AnimateSplineExtrude>();

        SplineExtrude splineExtrude = transform.Find(splineName).GetComponent<SplineExtrude>();

        splineExtrude.Radius = spline.m_Speed == .0001f ? 0.002f : 0;
        spline.m_Speed = spline.m_Speed == .0001f ? 0.27f : .0001f;
    }

    public void ToggleTrail(string splineName, bool turnOn)
    {
        /*
        GameObject trail = transform.Find(splineName).gameObject;

        trail.SetActive(turnOn);
        */

        AnimateSplineExtrude spline = transform.Find(splineName).GetComponent<AnimateSplineExtrude>();

        SplineExtrude splineExtrude = transform.Find(splineName).GetComponent<SplineExtrude>();

        splineExtrude.Radius = turnOn ? 0.002f : 0;
        spline.m_Speed = turnOn ? 0.27f : .0001f;
    }

    // Assign the trail tag to all trail/splines in game object for this to work
    public void ToggleAllTrails()
    {
        foreach (GameObject trail in GameObject.FindGameObjectsWithTag("Trail"))
        {
            ToggleTrail(trail.name);
        }
    }

    public void ToggleAllTrails(bool turnOn)
    {
        foreach (GameObject trail in GameObject.FindGameObjectsWithTag("Trail"))
        {
            ToggleTrail(trail.name, turnOn);
        }
    }
}
