using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroll : MonoBehaviour
{
    Vector2 checkpointpos;
    Rigidbody2D playerrb;

    private void Awake()
    {
      playerrb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        checkpointpos = transform.position;
    }



   


    

    public void updatecheckpoint(Vector2 pos)
    {
        checkpointpos = pos;
    }
   public void Die()
    {

        StartCoroutine(Respawn(.05f));


    }

    IEnumerator Respawn(float duration)
    {
        playerrb.simulated = false;
        playerrb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointpos;
        transform.localScale = new Vector3(1, 1, 1);
        playerrb.simulated = true;


    }
 }
