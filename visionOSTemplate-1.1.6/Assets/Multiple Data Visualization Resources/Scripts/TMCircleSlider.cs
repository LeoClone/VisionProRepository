using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TMCircleSlider : MonoBehaviour
{
 
     public bool b=true;
	 public Image image;
	 public float speed=0.5f;

  float time =0f;

 
  
  //public Text progress;
  public TextMeshProUGUI progress;


	void Update()
    {
		if(b)
		{
			time+=Time.deltaTime*speed;
			image.fillAmount= time;
			if(progress)
			{
		 
				progress.text = ((int)(image.fillAmount*100)).ToString();
 
			}
			
        if(time>1)
		{
						
			time=0;
		}
    }
	}
	
	
}
