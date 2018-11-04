using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoweUP : MonoBehaviour {
    public GameObject[] power;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    private int randEnemy;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
    }
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randEnemy = Random.Range(0,power.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1f, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(power[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            int randTime = Random.Range(5, 20);
            yield return new WaitForSeconds(randTime);
        }
    }
}
