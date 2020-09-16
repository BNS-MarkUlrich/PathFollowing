using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
//using Transform = UnityEngine.Transform;

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
            //Debug.Log("I return from NextWayPointLocation: " + gameObject.GetComponent<PathFollower>().NextWayPointLocation());
            gameObject.GetComponent<Path>()._currentWaypointIndex = 0;
        }

        public Waypoint NextWayPointLocation() // This needs to somehow be implemented
        {
            //Debug.Log("I return from NextWayPointLocation: " + gameObject.GetComponent<Path>().GetNextWaypoint());
            return gameObject.GetComponent<Path>().GetNextWaypoint();
        }

        /// <summary>
        /// TEST VERSION
        /// </summary>
        private void Update()
        {
            Vector3 heightOffsetPosition = new Vector3(gameObject.GetComponent<Path>()._waypoints[gameObject.GetComponent<Path>()._currentWaypointIndex].position.x, 
                transform.position.y, gameObject.GetComponent<Path>()._waypoints[gameObject.GetComponent<Path>()._currentWaypointIndex].position.z); // gameObject.GetComponent<PathFollower>().NextWayPointLocation();
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            //Debug.Log(gameObject.GetComponent<Path>()._waypoints[gameObject.GetComponent<Path>()._currentWaypointIndex]);

            if (distance <= _arrivalthreshold)
            {
                if (gameObject.GetComponent<Path>()._currentWaypointIndex == gameObject.GetComponent<Path>()._waypoints.Length-1)
                {
                    //print("Ik ben bij het eindpunt");

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






        //Debug lines below
        //Debug.Log("I return from NextWayPointLocation: " + gameObject.GetComponent<Path>().GetNextWaypoint());
        //Debug.Log(gameObject.GetComponent<Path>()._currentWaypointIndex);

        /// <summary>
        /// BACKUP VERSION
        /// </summary>
        //private void Update()
        //{

        //    Vector3 heightOffsetPosition = new Vector3(_waypoints[_currentWaypointIndex].position.x, transform.position.y, _waypoints[_currentWaypointIndex].position.z);
        //    float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        //    if (distance <= _arrivalthreshold)
        //    {
        //        transform.LookAt(heightOffsetPosition);
        //        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //    }
        //}
    }
}