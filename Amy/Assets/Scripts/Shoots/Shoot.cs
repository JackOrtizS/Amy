using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bulet;

    public float shootForce = 1500f;
    public float  shootRate = 0.5f;
    public float shootRateTine = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (Time.time>shootRateTine)
            {
                GameObject newBullet; ;

                newBullet = Instantiate(bulet, spawnPoint.position, spawnPoint.rotation);


                //La bala va hacia adelante
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

                //Tiempo para poder disparar
                shootRateTine = Time.time + shootRate;

                Destroy(newBullet, 5);
            }
        }
    }
}
