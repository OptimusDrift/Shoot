using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {
    public GameObject[] enemy;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop, stop2, finDeOleada;
    public int maxOleada, maxPantalla;
    public static int count;

    private int randEnemy;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
        stop = false; stop2 = true;
        maxPantalla = maxOleada / 2;
    }
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        if (Player.matados == maxOleada)
        {
            finDeOleada = true;
            maxOleada++;
            maxPantalla = maxOleada / 2;
            Player.matados = 0;
        }
        if (count >= maxPantalla || count >= maxOleada)
        {
            StopCoroutine(Spawner());
            stop = true;
            stop2 = true;
        }
        else if(stop2 && count < maxOleada)
        {
            StartCoroutine(Spawner());
            stop = false;
            stop2 = false;
        }
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            if (finDeOleada)
            {
                //mostrar cartel
                Debug.Log("Oleada Completada");
                finDeOleada = false;
                //yield return new WaitForSeconds(10f);
            }
            count++;
            randEnemy = 0;//Random.Range(0,2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1f, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemy[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
