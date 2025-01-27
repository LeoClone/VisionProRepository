﻿ 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMLineSlider : MonoBehaviour
{

    public bool b = true;
    public Image image;
    public float speed = 0.5f;

    float time = 0f;

    //public Text progress;
    public TextMeshProUGUI progress;
    private void Start()
    {
        image = GetComponent<Image>();
        speed = Random.Range(0.2f, 0.6f);
    }


    void Update()
    {
        if (b)
        {
            time += Time.deltaTime * speed;
            image.fillAmount = time;
            if (progress)
            {
                progress.text = ((int)(image.fillAmount * 100)).ToString();
            }

            if (time > 1)
            {

                time = 0;
            }
        }
    }

}
