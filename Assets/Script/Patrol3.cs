using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol3 : MonoBehaviour {
    public Transform[] waypints;
    public int num = 0;
    private Transform currentPatrolPoint;
    public float minDis;
    public float speed;
    public bool rand = false;
    public bool go = true;

    private void Start()
    {
        num = 0;
        currentPatrolPoint = waypints[num];
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position,currentPatrolPoint.position) <  .1f)
        {
            if (num + 1 < waypints.Length)
            {
                num++;
            }
            else
            {
                num = 0;
            }
            currentPatrolPoint = waypints[num];
        }
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

    }
}
