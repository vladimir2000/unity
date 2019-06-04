using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
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
        hp = 100;
    }

    void FixedUpdate()
    {
    	float moveVertical = Input.GetAxis("Vertical");
    	float moveHorizontal = Input.GetAxis("Horizontal");

    	rb.AddForce(transform.forward * moveVertical * 10f);
    	transform.Rotate(0f , moveHorizontal * 2f, 0f);

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            
            clone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            rbClone = clone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 1000f);
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp = hp - 12;
            HP.text = "HP : " + hp;

            if(hp <= 0)
            {
            SceneManager.LoadScene(1);
            hp = 100;
            }
        } 
    }
}	