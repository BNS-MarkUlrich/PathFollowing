using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    private List<Tower> components = new List<Tower>();

    private void Awake()
    {
        components.AddRange(GetComponents<Tower>());
        components.AddRange(GetComponentsInChildren<Tower>());

        foreach (Tower tow in components)
        {
            //Debug.Log(tow.name);
            //tow.enabled = false;
        }
    }

    public void ToggleComponents()
    {
        foreach (Tower mono in components)
        {
            //Debug.Log(mono.name);
            mono.enabled = !mono.enabled;
        }
    }
}
