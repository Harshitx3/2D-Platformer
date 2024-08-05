using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontriller : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothtime;
    public Vector3 postinoffset;
    [Header("Axis limitation")]
    public Vector2 xlimit;
    public Vector2 ylimit;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }



    private void LateUpdate()
    {
        Vector3 targetpostion = target.position + postinoffset;

        targetpostion = new Vector3(Mathf.Clamp(targetpostion.x, xlimit.x, xlimit.y), Mathf.Clamp(targetpostion.y, ylimit.x, ylimit.y), -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetpostion, ref velocity, smoothtime);
    }
}

