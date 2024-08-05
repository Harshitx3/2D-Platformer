using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    gamecontroll Gamecontroll;
    public Transform respawnpoint;


    SpriteRenderer spriterender;
    public Sprite assive, active;
    Collider2D coll;

    private void Awake()
    {
        Gamecontroll = GameObject.FindGameObjectWithTag("Player").GetComponent<gamecontroll>();
        spriterender = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamecontroll.updatecheckpoint(respawnpoint.position);
            spriterender.sprite = active;
            coll.enabled = false;
        }
    }




}
