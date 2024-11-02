using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalcontroler : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    Animation anim;
    Rigidbody2D playerrb;
    audiomanager Audiomanager;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animation>();
        playerrb =player. GetComponent<Rigidbody2D>();
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > .3f)
            {
                StartCoroutine(Portalin());
            }
        }
    }

    IEnumerator Portalin()
    {
        Audiomanager.PlaySpx(Audiomanager.inportal);
        playerrb.simulated = false;
        anim.Play("New Animation");
        yield return new WaitForSeconds(0.5f);
        player.transform.position = destination.position;
        anim.Play("out");
        Audiomanager.PlaySpx(Audiomanager.outportal);
        yield return new WaitForSeconds(0.5f);
        playerrb.simulated = true;
    }
}

