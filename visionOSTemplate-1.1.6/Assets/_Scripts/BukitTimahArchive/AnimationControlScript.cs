using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAnim();
        }
    }

    public void ToggleAnim()
    {
        if (anim.GetBool("StopAnim") == true)
        {
            anim.SetBool("StopAnim", false);
        }
        else
        {
            anim.SetBool("StopAnim", true);
        }
    }
}
