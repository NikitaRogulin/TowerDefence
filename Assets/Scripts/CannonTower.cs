using UnityEngine;
using System;
using System.Collections.Generic;

public class CannonTower : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float m_shootInterval/* = 0.5f*/;
    [SerializeField, Range(1, 10)] private float m_range /*= 4f*/;
    [SerializeField] private CannonProjectile m_projectilePrefab;
    [SerializeField] private Transform m_shootPoint;

    private Queue<Monster> m_queueEnemy;
    private DateTime m_dateShootTime;

    private void Awake()
    {
        m_queueEnemy = new Queue<Monster>();
    }
    void Update()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return;

        if(m_queueEnemy.Count != 0)
        {
            var enemy = m_queueEnemy.Peek();
            LookAtMonster(enemy);
            if (IsReloaded())
            {
                Shoot(enemy);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Monster>(out Monster monster))
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
    private void Shoot(Monster enemy)
    {
        //TO DO
        //STRELAT PO MONSTRAM:)
        Instantiate(m_projectilePrefab, m_shootPoint.position, Quaternion.identity);
    }
    private void LookAtMonster(Monster enemy)
    {

    }
    private bool IsReloaded()
    {
        if(m_shootInterval >= (DateTime.Now - m_dateShootTime).TotalSeconds)
        {
            return true;
        }
        return false;
    }
}
