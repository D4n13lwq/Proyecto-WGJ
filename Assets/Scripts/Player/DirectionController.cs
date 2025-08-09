using UnityEngine;

public class DirectionController
{
    [SerializeField] bool _lookingRight = true;
    public bool LookingRight => _lookingRight;

    public void HandleOrientation(float horizontal, Transform transform)
    {
        if ((_lookingRight && horizontal < 0) || (!_lookingRight && horizontal > 0))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            _lookingRight = !_lookingRight;
        }
    }

    public void HandleOrientation(bool value, Transform transform)
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        _lookingRight = value;
    }
}
