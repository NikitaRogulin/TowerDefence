using UnityEngine;
using System;
using System.Collections.Generic;

public class CannonTower : Tower
{
    [SerializeField] private CannonProjectile m_projectilePrefab;
    [SerializeField] private float m_speedRotation;

    void Update()
    {
        if (m_projectilePrefab == null || m_shootPoint == null)
            return;

        ProtectQueue();

        if (m_queueEnemy.Count != 0)
        {
            var enemy = m_queueEnemy.Peek();
            LookAtMonster(enemy);
            if (IsReloaded())
            {
                Shoot(enemy);
            }
        }
    }
    private void ProtectQueue()
    {
        while(m_queueEnemy.Count != 0)
        {
            var first = m_queueEnemy.Peek();
            if (first == null)
                m_queueEnemy.Dequeue();
            else
                return;
        }
    }
    private void Shoot(Monster enemy)
    {
        var projectile = Instantiate(m_projectilePrefab, m_shootPoint.position, Quaternion.identity);
        var projectileDirection = FindShootVector(projectile, enemy);
        projectile.Init(projectileDirection);
        m_dateShootTime = DateTime.Now;
    }
    private void LookAtMonster(Monster enemy)
    {
        var direction = enemy.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * m_speedRotation).eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
    private Vector3 FindShootVector(CannonProjectile projectile, Monster monster)
    {

        var delta = m_shootPoint.position - monster.transform.position;
        var Mp = monster.transform.position;
        var Cp = m_shootPoint.position;
        var monstrDirection = monster.GetDirection();
        var dx = delta.x;
        var dy = delta.y;
        var Vm = monster.Speed;
        var Vp = projectile.Speed;
        var angle = Mathf.PI*(Vector3.SignedAngle(monster.GetDirection(), delta,-Vector3.up))/180f;
        var cos = Mathf.Cos(angle);
        var d = 4 * cos * cos * Vm * Vm * delta.sqrMagnitude - 4 * delta.sqrMagnitude * (Vm * Vm - Vp * Vp);
        var t = (2 * cos * Vm * delta.magnitude - Mathf.Sqrt(d))/(2* (Vm * Vm - Vp * Vp));

        var r = -delta / (t * Vp) + (Vm * monstrDirection) / Vp;
        return r;
    }
}
