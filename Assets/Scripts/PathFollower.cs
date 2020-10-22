using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>

    public class PathFollower : MonoBehaviour
    {

        [SerializeField] public UnityEvent onPathComplete;


        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private float _arrivalthreshold = 0.1f;

        private Path getPath;

        private Waypoint currentWaypoint;

        private void Awake()
        {            
            getPath = GameObject.FindObjectOfType<Path>();
            //getPath._currentWaypointIndex = 0;
            currentWaypoint = getPath.GetNextWaypoint(currentWaypoint);
            //Debug.Log(currentWaypoint);
        }

        public Vector3 EnemyPosition { get { return transform.position; } }

        private void Update()
        {
            // OLD Begin
            //Vector3 heightOffsetPosition = new Vector3(gameObject.GetComponent<Path>().GetNextWaypoint().WaypointLocation.x, 
            //    transform.position.y, gameObject.GetComponent<Path>().GetNextWaypoint().WaypointLocation.z);
            // OLD End
            Vector3 heightOffsetPosition = new Vector3(currentWaypoint.WaypointLocation.x, currentWaypoint.WaypointLocation.y, currentWaypoint.WaypointLocation.z); // was transform.position.y
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);


            if (distance <= _arrivalthreshold)
            {
                //Debug.Log("Hier is distance:");
                currentWaypoint = getPath.GetNextWaypoint(currentWaypoint);
                if (currentWaypoint == null)
                {
                    onPathComplete?.Invoke();
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
