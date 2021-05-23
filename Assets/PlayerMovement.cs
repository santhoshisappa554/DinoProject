using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float playerSpeed;
    public GameObject myPrefab;
    //public GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Obstaclegeneration", 0.5f, 8f);
        Instantiate(myPrefab, new Vector3(28, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        JumpMovement();
        this.GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
    }
    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ground")
        {
            JumpMovement();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleBehaviour>() != null)
        {
            Destroy(this.gameObject);
            print("GameOver");
        }

    }
    private void JumpMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0));
            Debug.Log("jumped");
        }
    }
   /* void Obstaclegeneration()
    {
        //click the instantiate button and new prefab will be instantiated.
        //instantiated with a random number of items in each direction.
        // int x= Random.Range(-3, 10);
        Instantiate(Obstacle, transform.position + new Vector3(5, 0, 0), transform.rotation);

    }*/


}

