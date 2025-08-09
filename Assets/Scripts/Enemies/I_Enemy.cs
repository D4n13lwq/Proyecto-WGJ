using System.Collections.Generic;
using UnityEngine;

public interface I_Enemy
{
    public List<GameObject> parts { get; set; }

    public void Lighted();
    public void Unlighted();
}
