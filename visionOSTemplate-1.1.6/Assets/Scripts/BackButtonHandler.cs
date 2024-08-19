using System;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonHandler : MonoBehaviour
{
    public static event Action OnBackButtonClicked;

    private Button backButton;

    private void Awake()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        OnBackButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(ButtonClicked);
    }
}
