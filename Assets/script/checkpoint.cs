using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    gamecontroll Gamecontroll;
    public Transform respawnpoint;
    audiomanager Audiomanager;


    SpriteRenderer spriterender;
    public Sprite assive, active;
    Collider2D coll;

    private void Awake()
    {
        Gamecontroll = GameObject.FindGameObjectWithTag("Player").GetComponent<gamecontroll>();
        spriterender = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        Audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Audiomanager.PlaySpx(Audiomanager.checkpoint);
            Gamecontroll.updatecheckpoint(respawnpoint.position);
            spriterender.sprite = active;
            coll.enabled = false;
        }
    }




}
