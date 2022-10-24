using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Tower : MonoBehaviour
{
    [SerializeField, Range(0, 10)] protected float m_shootInterval;
    [SerializeField] protected Transform m_shootPoint;

    protected Queue<Monster> m_queueEnemy;
    protected DateTime m_dateShootTime;

    private void Awake()
    {
        m_queueEnemy = new Queue<Monster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Monster>(out Monster monster))
        {
            m_queueEnemy.Enqueue(monster);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Monster>(out Monster monster))
        {
            m_queueEnemy.Dequeue();
        }
    }
    protected bool IsReloaded()
    {
        if (m_shootInterval <= (DateTime.Now - m_dateShootTime).TotalSeconds)
        {
            return true;
        }
        return false;
    }
}