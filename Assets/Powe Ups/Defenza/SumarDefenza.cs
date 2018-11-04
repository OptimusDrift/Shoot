using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarDefenza : MonoBehaviour
{
    bool TimerStarted = false;
    bool primera = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!TimerStarted) TimerStarted = true;
    }

    private float _timer = 0f;
    public float TimeIWantInSeconds = 10f;

    void Update()
    {
        if (TimerStarted)
        {
            if (primera)
            {
                EnemyProjectile.damage -= 2;
                primera = false;
                Destroy(gameObject.GetComponent<Renderer>());
                Destroy(gameObject.GetComponent<Collider2D>());
            }
            _timer += Time.deltaTime;

            if (_timer >= TimeIWantInSeconds)
            {
                EnemyProjectile.damage += 2;
                primera = true;
                Destroy(gameObject);
            }
        }
    }
}

