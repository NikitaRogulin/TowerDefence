using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Range(10, 100)] protected float m_speed;
    [SerializeField] protected int m_damage;
    protected void Move()
    {
        transform.Translate(Direction() * m_speed * Time.deltaTime);
    }
    protected void Delete()
    {
        Destroy(gameObject);
    }
    protected abstract Vector3 Direction();
}
