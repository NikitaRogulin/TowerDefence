using UnityEngine;
using System.Collections;
using System;

public class SimpleTower : Tower
{
    [Header("Prefab")]
    [SerializeField] private GuidedProjectile m_projectilePrefab;

    void Update()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return;

        ProtectQueue();
        if (m_queueEnemy.Count != 0)
        {
            var enemy = m_queueEnemy.Peek();
            if (IsReloaded())
            {
                Shoot(enemy);
            }
        }
    }
    private void Shoot(Monster enemy)
    {
        var projectile = Instantiate(m_projectilePrefab, m_shootPoint.position, Quaternion.identity);
        projectile.Init(enemy.transform);
        m_dateShootTime = DateTime.Now;
    }
    private void ProtectQueue()
    {
        while (m_queueEnemy.Count != 0)
        {
            var first = m_queueEnemy.Peek();
            if (first == null)
                m_queueEnemy.Dequeue();
            else
                return;
        }
    }
}
