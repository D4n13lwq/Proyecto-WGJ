using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger("Died");
    }
}
