using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    private float maxhealth = 100;
    private float currenthealth;
    [SerializeField] private Image healthbarfull;
    [SerializeField] private gamecontroll Game;
    public float damge;
    [SerializeField] private Transform healthbartransform;
    private Camera camera;


    private void Awake()
    {
        currenthealth = maxhealth;
        camera = Camera.main;
    }

    private void Update()
    {
        healthbartransform.rotation = camera.transform.rotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obsticle"))
        {
            TakeDamage(damge);
        }
    }


    private void TakeDamage(float amount)
    {
        currenthealth -= amount;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);
        if(currenthealth == 0)
        {
            Game.Die();
            currenthealth = maxhealth;
        }
        updatehealth();
    }


    private void updatehealth()
    {
        healthbarfull.fillAmount = currenthealth / maxhealth;
    }
}