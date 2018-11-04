using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarBalas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weapon.cargadorUsado += 15;
        weapon.cantBalas = weapon.Cargar();
        Destroy(gameObject);
    }
}

