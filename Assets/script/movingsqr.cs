
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingsqr : MonoBehaviour
{
    public float speed;
    Vector3 targetpos;

    public GameObject ways;
    public Transform[] waypoint;
    int pointindex;
    int pointcount;
    int direction = 1;


    private void Awake()
    {
        waypoint = new Transform[ways.transform.childCount];
        for(int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            waypoint[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointcount = waypoint.Length;
        pointindex = 1;
        targetpos = waypoint[pointindex].transform.position;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetpos, step);

        if(transform.position == targetpos)
        {
            NextPoint();
        }
    }


    void NextPoint()
    {
        if(pointindex  == pointcount - 1)
        {
            direction = -1;
        }

        if(pointindex == 0)
        {
            direction = 1;
        }


        pointindex += direction;
        targetpos = waypoint[pointindex].transform.position;
    }


}
