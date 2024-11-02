using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Effect : MonoBehaviour
{
    Vector2 startpos;










    Rigidbody2D rb;
  


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void Start()
    {
        startpos = transform.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = startpos;
        }
    }


}
