using UnityEngine;

public class B_Raven : Enemy
{
    [SerializeField] Animator anim;

    private void Start()
    {
        Start_Enemy();
    }

    protected override void Start_Enemy()
    {
        anim = GetComponent<Animator>();
        base.Start_Enemy();
    }

    public override void Lighted()
    {
        anim.SetTrigger(name:"Lighted");
        base.Lighted();
    }
}
