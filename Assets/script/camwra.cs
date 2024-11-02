using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camwra : MonoBehaviour
{
    public float followspeed = 2f;
    public float yofset = 1f;
    public Transform target;

    private void Update()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y*yofset, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, followspeed * Time.deltaTime);
    }
}
