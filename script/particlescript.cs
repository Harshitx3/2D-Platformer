using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlescript : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementparticle;
    [SerializeField] ParticleSystem fallparticle;
    [SerializeField] ParticleSystem touchparticle;


    [Range(0, 10)]
    [SerializeField] int occuraftervelocity;

    [Range(0, .2f)]
    [SerializeField] float dustformationperiod;
    [Header("")]
    [SerializeField] Rigidbody2D playerrb;
    bool isongrd;


    float counter;


    private void Start()
    {
        touchparticle.transform.parent = null;
    }
    private void Update()
    {
        counter += Time.deltaTime;

        if (isongrd && Mathf.Abs(playerrb.velocity.x) > occuraftervelocity)
        {
            if (counter > dustformationperiod)
            {
                
                movementparticle.Play();
                counter = 0;
            }
        }
    }

    public void Playtouchparticle(Vector2 pos)
    {
        touchparticle.transform.position = pos;
        touchparticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            fallparticle.Play();
            isongrd = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isongrd = false;
        }
    }



























}

