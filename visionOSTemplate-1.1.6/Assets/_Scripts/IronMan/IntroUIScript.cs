using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomDuration = Random.Range(0.5f, 1.5f);

        transform.localScale = Vector3.zero;

        LeanTween.scale(gameObject, Vector3.one, randomDuration).setEase(LeanTweenType.easeInOutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
