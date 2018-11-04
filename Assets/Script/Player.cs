using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator camAnim;
    public float health;
    public GameObject deathEffect;
    public GameObject explosion;
    public RectTransform rectTransform;
    public static int matados;
    public static int totalMatados;
    private void Start()
    {
        rectTransform = GameObject.FindGameObjectWithTag("Health").GetComponent<RectTransform>();
        matados = 0;
        totalMatados = 0;
    }
    private void Update()
    {
        float UpdateLife = Mathf.MoveTowards(rectTransform.rect.height, health, 5.0f);
        rectTransform.sizeDelta = new Vector2(100f, Mathf.Clamp(UpdateLife, 0.0f, 100f));

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;

    }
}