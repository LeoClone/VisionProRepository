using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailsNavigationScript : MonoBehaviour
{
    public string imageName;
    public string videoName;
    public string description;

    public GameObject initialPanel;
    public GameObject detailPanel;
    public Image detailImage;
    public TMP_Text detailDescription;

    public ScrollRect scrollRect;
    public RectTransform initialContent;
    public RectTransform initialViewport;
    public RectTransform detailContent;
    public RectTransform detailViewport;
    //video

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDetail()
    {
        detailImage.sprite = Resources.Load<Sprite>(imageName);
        detailDescription.text = description;

        initialPanel.SetActive(false);
        detailPanel.SetActive(true);

        scrollRect.content = detailContent;
        scrollRect.viewport = detailViewport;
    }

    public void CloseDetail()
    {
        detailPanel.SetActive(false);
        initialPanel.SetActive(true);

        scrollRect.content = initialContent;
        scrollRect.viewport = initialViewport;
    }
}
