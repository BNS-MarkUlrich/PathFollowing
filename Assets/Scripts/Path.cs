using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
    /// Deze vormen samen het pad. 
    /// Logica die op het path niveau plaatsvindt gebeurt in deze class.
    /// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
    /// </summary>
    public class Path : MonoBehaviour
    {

        [SerializeField] public Transform[] _waypoints; // Mark: maybe try Vector3[]

        public int _currentWaypointIndex;

        /// <summary>
        /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
        /// </summary>
        public Waypoint GetNextWaypoint() //TEST = Vector3
        {
            //if (_currentWaypointIndex == _waypoints.Length - 1)
            //{
            //    print("Ik ben bij het eindpunt");

            //}
            return _waypoints[_currentWaypointIndex].gameObject.GetComponent<Waypoint>(); //removed .WaypointLocation
        }
    }
}