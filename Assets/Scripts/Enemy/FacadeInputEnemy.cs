using UnityEngine;

internal class FacadeInputEnemy : IFacadeInput
{
    private Follower _target;
    private readonly GameObject _from;
    private bool _canMove = true;

    public FacadeInputEnemy(GameObject from)
    {
        _from = from;
    }

    public Vector2 GetDirection()
    {
        if (_target == null || !_canMove) return Vector2.zero;
        var direction = _target.transform.position - _from.transform.position;
        Debug.DrawLine(_from.transform.position, _target.transform.position, Color.red);
        return new Vector2(direction.x, direction.z).normalized;
    }

    public void SetTarget(Follower target)
    {
        _target = target;
    }

    public void IsDead()
    {
        _canMove = false;        
    }
}