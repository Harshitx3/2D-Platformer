using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class movementcontroiller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed;
    [Range(1, 10)]
    [SerializeField] private float acc;
    float speedmult;
    bool btnpressed;

    bool iswalltouch;
    public LayerMask walllayer;
    public Transform wallcheckpoint;

    Vector2 relativeTransform;
    public bool isonplat;
    public Rigidbody2D platform;
   // bool forward;
    public particlescript particlescript;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    private void Start()
    {
        updateRelative();
    }

    private void FixedUpdate()
    {
        updatespeedmult();
        float targetspeed = speed * speedmult*relativeTransform.x;


        //if (forward)
       // {

          //  rb.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
        

        if (isonplat)
        {
            rb.velocity = new Vector2(targetspeed+platform.velocity.x, rb.velocity.y);

        }
        else
        {
            rb.velocity = new Vector2(targetspeed, rb.velocity.y);

        }



        iswalltouch = Physics2D.OverlapBox(wallcheckpoint.position, new Vector2(.29f, .72f), 0, walllayer);
        if (iswalltouch)
        {
            flip();
        }
            



    }
   
    void flip()
    {
        particlescript.Playtouchparticle(wallcheckpoint.position);
        transform.Rotate(0, 180, 0);
        updateRelative();
       
    }

    void updateRelative() {

        relativeTransform = transform.InverseTransformVector(Vector2.one);

    }


    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            btnpressed = true;
            
           
        }
        else if (value.canceled)
        {
            btnpressed = false;
          
           
        }
    }
    
    private void updatespeedmult()
    {
        if( btnpressed && speedmult < 1)
        {
            speedmult += Time.deltaTime*acc;

        }

        else if(!btnpressed && speedmult > 0)
        {
            speedmult -= Time.deltaTime*acc;
        }
    }
    /*public void isTriggerright(bool canmoveright)
    {
        forward = canmoveright;
    }*/
}