using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlescript : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementparticle;
    [SerializeField] ParticleSystem fallparticle;
    [SerializeField] ParticleSystem touchparticle;
    audiomanager Audiomanager;


    [Range(0, 10)]
    [SerializeField] int occuraftervelocity;

    [Range(0, .2f)]
    [SerializeField] float dustformationperiod;
    [Header("")]
    [SerializeField] Rigidbody2D playerrb;
    bool isongrd;


    float counter;

    private void Awake()
    {
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

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
        Audiomanager.PlaySpx(Audiomanager.wall);
        touchparticle.transform.position = pos;
       
        touchparticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Audiomanager.PlaySpx(Audiomanager.wall);
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

