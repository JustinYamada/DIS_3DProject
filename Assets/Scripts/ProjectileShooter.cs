using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [Tooltip("How fast is the projectile moving")]
    public float speed = 10;
    [Tooltip("After how many seconds is the projectile destroyed")]
    public float lifeTime = 3;

    [Tooltip("The direction the BounceObject travels")]
    public Vector3 direction;
    public GameObject player;
    Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPos, direction, (3- lifeTime)/3);

        lifeTime -= Time.unscaledDeltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
