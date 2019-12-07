using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("Prefab to be instantiated when shooting (Projectile)")]
    public GameObject projectilePrefab;
    private float lastTimeFired = 0;
    [Tooltip("How fast is the boss shooting")]
    public float rateOfFire = 1;
    public GameObject player;

    public AudioClip bossSound;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        // if the fire button is pressed and we waited long enough since the last shot was fired, FIRE!
        if ((lastTimeFired + 3 / rateOfFire) < Time.time)
        {
            lastTimeFired = Time.time;
            FireTheBounce();
        }
    }

    void FireTheBounce()
    {
        AudioSource.PlayClipAtPoint(bossSound, player.transform.position);
        StartCoroutine(WaitCoroutine());
    }

    

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);
    }

}
