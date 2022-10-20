using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{

    [SerializeField, Range(0, 1)] private float m_speed;
    [SerializeField, Range(1, 100)] private int m_hp;
    private Transform m_moveTarget;

    public void Init(Transform target)
    {
        m_moveTarget = target;
    }
    void Update()
    {
        if (m_moveTarget == null)
            return;

        Move();

        if (IsDeath())
        {
            Death();
        }
    }
    private void Move()
    {
        var distance = m_moveTarget.transform.position - transform.position;
        var direction = distance.normalized;
        var delta = direction * m_speed * Time.deltaTime;
        MoveToTarget(delta);
    }
    private void Death()
    {
        Destroy(gameObject.transform);
    }
    private bool IsDeath()
    {
        return m_hp <= 0 || transform.position == m_moveTarget.position;
    }
    private void MoveToTarget(Vector3 vector)
    {
        MoveToTarget(vector.magnitude);
    }
    private void MoveToTarget(float distance)
    {
        transform.position = Vector3.MoveTowards(transform.position, m_moveTarget.position, distance);
    }
}
