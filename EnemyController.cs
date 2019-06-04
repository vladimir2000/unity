using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Text Score;
    public NavMeshAgent enemy;
    static int score;


    void Start()
    {
        score = 0;
    }

    void FixedUpdate()
    {
        enemy.SetDestination(player.transform.position);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            score = score + 1;
            Score.text = "Score : " + score;

            if(score >= 5)
            {
            SceneManager.LoadScene(0); 
            score = 0;
            }

        } 
    }
}
