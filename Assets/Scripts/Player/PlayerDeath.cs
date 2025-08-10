using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger("Die");
>>>>>>> Stashed changes
    }
}
