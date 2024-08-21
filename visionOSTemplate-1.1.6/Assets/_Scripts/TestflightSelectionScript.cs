using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestflightSelectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTestflightProject(string projectName)
    {
        SceneManager.LoadScene(projectName);
    }

    public void BackHome()
    {
        SceneManager.LoadScene("MultiTestFlightStart");
    }
}
