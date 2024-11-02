using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class movingplat : MonoBehaviour
{
 
    public float speed;
    Vector3 targetpos;


    movementcontroiller    movementcontr;

    Rigidbody2D rb;
    Vector3 moveDirection;
  
    Rigidbody2D playerRb;

    public GameObject Ways;
    public Transform[] waypoint;
    int pointindex;
    int pointCount;
    int direction = 1;
    public float waitDirection;


    private void Awake()
    {
       
        movementcontr = GameObject.FindGameObjectWithTag("Player").GetComponent<movementcontroiller>();
        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        waypoint = new Transform[Ways.transform.childCount]; 

        for (int i = 0; i < Ways.gameObject.transform.childCount; i++)
        {
            waypoint[i] = Ways.transform.GetChild(i).gameObject.transform; 
        }
    }


    private void Start()
    {
        pointindex = 1;
        pointCount = waypoint.Length;
        targetpos = waypoint[1].transform.position;


        dirncalculate();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position , targetpos) < .5f)
        {

            NextPoint();
        }


        



           
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void NextPoint()
    {
        transform.position = targetpos;
        moveDirection = Vector3.zero;


        if(pointindex == pointCount - 1)
        {
            direction = -1;
        }
        if(pointindex == 0)
        {
            direction = 1;
        }
        pointindex += direction;
        targetpos = waypoint[pointindex].transform.position;
        StartCoroutine(WaitNextpoint());


    }


    IEnumerator WaitNextpoint()
    {
        yield return new WaitForSeconds(waitDirection);
        dirncalculate();
    }

    private void dirncalculate()
    {
        moveDirection = (targetpos - transform.position).normalized;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementcontr.isonplat = true;
            
            movementcontr.platform = rb;
            
            playerRb.gravityScale = playerRb.gravityScale * 50;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementcontr.isonplat = false;
            
            
            playerRb.gravityScale = playerRb.gravityScale / 50;
        }
    }
    
}
