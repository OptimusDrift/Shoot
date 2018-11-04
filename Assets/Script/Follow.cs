using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public float speed;
    public float stop;

    private bool giro;
    private Transform target;
    public Transform arma;
    private Vector3 pos;
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        giro = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, target.position) > stop && Vector2.Distance(transform.position, target.position) < stop * 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            pos = target.position - transform.position;
            if (arma.transform.rotation.z >= 0f)
            {
                if (!giro)
                {
                    transform.Rotate(new Vector3(0f, 180f, 0f));
                    giro = true;
                }
            }
            else if (arma.transform.rotation.z <= 0 && giro)
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
                giro = false;
            }
        }
	}
}
