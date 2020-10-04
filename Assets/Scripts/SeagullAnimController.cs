using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullAnimController : MonoBehaviour
{
    Animator animator;
    public int startAnim;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("anim", startAnim);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
