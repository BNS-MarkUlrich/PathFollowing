using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefenceTower : MonoBehaviour
{
    [SerializeField] private float _barrierthreshold = 1.1f;
    [SerializeField] private UnityEvent onBarrierHit;

    // Update is called once per frame
    void Update()
    {
        
        Vector3 _currentEnemyPosition = new Vector3(FindObjectOfType<PathFollower>().EnemyPosition.x, FindObjectOfType<PathFollower>().EnemyPosition.y, FindObjectOfType<PathFollower>().EnemyPosition.z);
        float Barrierdistance = Vector3.Distance(transform.position, _currentEnemyPosition);

        if (Barrierdistance <= _barrierthreshold)
        {
            onBarrierHit?.Invoke();
        }

        if (FindObjectsOfType<PathFollower>() == null)
        {
            gameObject.SetActive(false);
            print("Enemy missed!");
        }
    }
}
