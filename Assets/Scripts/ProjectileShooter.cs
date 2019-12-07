using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [Tooltip("How fast is the projectile moving upwards")]
    public float speed = 10;
    [Tooltip("After how many seconds is the projectile destroyed")]
    public float lifeTime = 3;

    [Tooltip("The direction the laster travels")]
    public Vector3 direction;
    public GameObject player;
    Vector3 startPos;
    public Rigidbody rb;


    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        //direction = player.transform.position;
        direction = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        // normalize direction so it does not impact the travel speed
        //direction.Normalize();





        // make the projectile rotate into the direction it is moving, math will be addressed in lecture 2
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

    }

    void Update()
    {
        //Debug.Log(player.transform.position.y);
        transform.position = Vector3.Lerp(startPos, direction, (3- lifeTime)/3);
        print((3 - lifeTime) / 3);
        //rb.AddForce(direction);

        lifeTime -= Time.unscaledDeltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
