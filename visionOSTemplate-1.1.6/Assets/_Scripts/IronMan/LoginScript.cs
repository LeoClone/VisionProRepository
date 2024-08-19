using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginScript : MonoBehaviour
{
    [SerializeField] string username;
    [SerializeField] string password;
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField passwordField;

    [SerializeField] GameObject loadingText;
    [SerializeField] GameObject[] loginUIs;

    [SerializeField] GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        loadingText.gameObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogIn()
    { 
        if ((usernameField.text == "admin" || usernameField.text == "") && (passwordField.text == "123" || passwordField.text == ""))
        {
            Debug.Log("correct");

            foreach(GameObject _ui in loginUIs)
            {
                _ui.SetActive(false);
            }

            loadingText.gameObject.transform.localScale = Vector3.one;

            LeanTween.scale(loadingText, Vector3.one, 1.5f).setOnComplete(CloseUI);
            
            
        }
    }

    void CloseUI()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setOnComplete(OpenMain);

        
    }

    void OpenMain()
    {
        gameObject.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
