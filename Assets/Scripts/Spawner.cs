using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField, Range(4,10)] private float m_interval;
    [SerializeField] private Monster m_monsterPrefab;
    [SerializeField] private Transform target;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            var newMonster = Instantiate(m_monsterPrefab, transform.position, Quaternion.identity);
            newMonster.Init(target);
            yield return new WaitForSeconds(m_interval);
        }
    }
}
