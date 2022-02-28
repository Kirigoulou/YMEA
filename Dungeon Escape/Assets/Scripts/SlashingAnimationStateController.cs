using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingAnimationStateController : MonoBehaviour
{
    private Animator animator;
    
    private int slashState = 0, nbSlash = 3;

    private const float COOLDOWNCONSTANT = 0.5f;
    private float coolDown;

    private bool slashed = false;    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool attackPress = Input.GetKey(KeyCode.Mouse0);

        if (attackPress)
        {
            animator.SetBool("IsSlashing", true);
            slashState = (slashState + 1) % nbSlash;
            animator.SetInteger("nbSlash", slashState);
            coolDown = Time.time + COOLDOWNCONSTANT;
            slashed = true;
            Debug.Log(slashState);
        }
        
        if (coolDown < Time.time && slashed)
        {
            slashState = 0;
            animator.SetInteger("nbSlash", 0);
            animator.SetBool("IsSlashing", false);
            slashed = false;
        }
    }
}
