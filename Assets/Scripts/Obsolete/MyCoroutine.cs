using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This entire scripts can be ignored, serves as simple storage for later reference
/// </summary>
public class MyCoroutine : MonoBehaviour
{
    private new MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade()
    {
        //Debug.Log("Hello World");
        //yield return new WaitForSeconds(3);
        //Debug.Log("Hello World again");
        Material mat = renderer.material;

        mat.color += new Color(0.1f, 0.1f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        mat.color = new Color(0.2f, 0.8f, 0.2f);

        //while (true)
        //{
        //    mat.color += new Color(0.2f, 0.2f, 0.2f);
        //    yield return null;
        //    mat.color += new Color(0.2f, 0.8f, 0.2f);
        //}
    }
}
/// <summary>
/// [09:33] Calvin Davidson
///Ik heb het gebruikt voor een simple animatie met de healthbar, Dat hij naar ze nieuwe health lerpt, 
/// </summary>
/// <returns></returns>

// Coroutine: useful for things that need to return things in intervals or keypresses (think defence towers shooting in set intervals)
// Can also use coroutines to shortly change for example colour of an object/text/etc as they are taking damage