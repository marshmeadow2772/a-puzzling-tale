
using UnityEngine;

public class FlipDover : MonoBehaviour
{
    [SerializeField] int _speed;
    Rigidbody2D _rb2d;
    private float _horizonatlMove;
    private bool _isFacingRight = false;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizonatlMove = _rb2d.velocity.x;

        if(_isFacingRight &&  _horizonatlMove < 0)
        {
            Flip();
        }
        else if(!_isFacingRight && _horizonatlMove > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, -180f, 0.0f);
    }
}
