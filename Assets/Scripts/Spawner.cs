using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float m_interval;
    [SerializeField] private Monster m_monsterPrefab;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        //	monsterBeh.m_moveTarget = m_moveTarget;
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(m_monsterPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(m_interval);
        }
    }
}
