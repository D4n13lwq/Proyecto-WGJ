using UnityEngine;

public class PussyParticleDestroyer : MonoBehaviour
{
    [SerializeField] float time;

    private void OnEnable()
    {
        Destroy(gameObject, time);
    }
}
