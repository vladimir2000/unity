using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
	Rigidbody rb;
    Rigidbody rbClone;
    public Text HP;
    public GameObject bullet;
    GameObject clone;
    int hp;
	
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        hp = 10;
    }

    void FixedUpdate()
    {
    	float moveVertical = Input.GetAxis("Vertical");
    	float moveHorizontal = Input.GetAxis("Horizontal");

    	rb.AddForce(transform.forward * moveVertical * 20f);
    	rb.AddForce(transform.right * moveHorizontal * 20f);

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            
            clone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            rbClone = clone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 1000f);
        }
        if(hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP.text = "HP : 0";
            hp = hp - 1;
            Debug.Log(hp);
            HP.text = "HP : " + hp;
        } 
    }
}	