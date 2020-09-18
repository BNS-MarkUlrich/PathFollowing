using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>

    public class PathFollower : MonoBehaviour
    {
        

        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private float _arrivalthreshold = 0.1f;


        private void Start()
        {            
            gameObject.GetComponent<Path>()._currentWaypointIndex = 0;
        }

        private void Update()
        {
            Vector3 heightOffsetPosition = new Vector3(gameObject.GetComponent<Path>().GetNextWaypoint().WaypointLocation.x, 
                transform.position.y, gameObject.GetComponent<Path>().GetNextWaypoint().WaypointLocation.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            if (distance <= _arrivalthreshold)
            {
                if (gameObject.GetComponent<Path>()._currentWaypointIndex == gameObject.GetComponent<Path>()._waypoints.Length-1)
                {
                    print(message: "Ik ben bij het eindpunt");

                }
                else
                {
                    gameObject.GetComponent<Path>()._currentWaypointIndex++;
                }            
            }
            else
            {
                transform.LookAt(heightOffsetPosition);
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
        }
    }
}