using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{

    [SerializeField, Range(20, 40)] private float m_speed;
    [SerializeField, Range(1, 100)] private int m_hp;
    private Transform m_moveTarget;

    public float Speed => m_speed;
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
    public void Hit(int damage)
    {
        m_hp -= damage;
        if(IsDeath())
        {
            Death();
        }
    }
    private void Move()
    {
        var delta = GetDirection() * m_speed * Time.deltaTime;
        MoveToTarget(delta);
    }
    public Vector3 GetDirection()
    {
        return (m_moveTarget.transform.position - transform.position).normalized;
    }
    private void Death()
    {
        Destroy(gameObject);
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
