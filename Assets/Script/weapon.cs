using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    public Animator camAnim;
    public static int cantBalas = 30;
    public static int cantCarg = 3;
    public int maximoCargadores = 6;
    public static int cargadorUsado = 0;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public static int Cargar()
    {
        if (cantBalas > 0)
        {
            cargadorUsado += cantBalas;
            cantBalas = 0;
        }
        while (cargadorUsado >= 30 && cantCarg <= 6)
        {
            cargadorUsado -= 30;
            cantCarg++;
        }
        if (cantCarg == 7)
        {
            cargadorUsado = 0;
        }
        if (cantCarg > 0)
        {
            cantCarg--;
            return 30;
        }
        else
        {
            int aux = cargadorUsado;
            cargadorUsado = 0;
            return aux;
        }
    }
    private void Update()
    {
        Debug.Log(cantCarg);
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (Input.GetKeyDown(KeyCode.R) && cantCarg > 0)
        {
            cargadorUsado += cantBalas;
            Debug.Log(cantBalas);
            cantBalas = 0;
            Debug.Log(cantBalas);
            cantBalas = Cargar();
            Debug.Log(cantBalas);
        }
        if (cantBalas <= 0)
        {
            if (cargadorUsado > 0)
            {
                Debug.Log("Recargando");
                cantBalas = Cargar();
            }
        }
        if (timeBtwShots <= 0 && cantBalas > 0)
        {
            if (Input.GetMouseButton(0))
            {
                cantBalas--;
                Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                camAnim.SetTrigger("shake");
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}