using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    [SerializeField] GameObject objectToRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateObject(float value)
    {
        float rotation = value * 360f;

        //Debug.Log(rotation);

        objectToRotate.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
