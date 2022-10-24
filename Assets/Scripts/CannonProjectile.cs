using UnityEngine;
using System.Collections;

public class CannonProjectile : Projectile
{
    public float Speed => m_speed;
    private Vector3 direction;
    public void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
    }
    void Update()
    {
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Monster>(out Monster monster))
        {
            monster.Hit(m_damage);
            Delete();
        }
    }
    protected override Vector3 Direction()
    {
        return direction;
    }
}