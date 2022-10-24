using UnityEngine;
using System.Collections;

public class GuidedProjectile : Projectile
{
    private Transform m_target;

    public void Init(Transform target)
    {
        m_target = target;
    }
    void Update()
    {
        if (m_target != null)
            Move();
        if (m_target == null)
        {
            Delete();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Monster>(out Monster monster))
        {
            monster.Hit(m_damage);
            Delete();
        }
    }
    protected override Vector3 Direction()
    {
        var distance = m_target.transform.position - transform.position;
        var direction = distance.normalized;
        return direction;
    }
}

