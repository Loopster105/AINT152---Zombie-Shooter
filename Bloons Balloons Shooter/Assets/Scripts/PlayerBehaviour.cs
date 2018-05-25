using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public GameObject gameOverPanel;
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;
    //private Animator gunAnim;

    void Start()
    {
        //gunAnim = GetComponent<Animator>();
        SendHealthData();
        gameOverPanel.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().PlaySound("");
            //GetComponent<Animator>().SetBool("isFiring", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //GetComponent<Animator>().SetBool("isFiring", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            Die();
            Time.timeScale = 0f;
        }
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().PlaySound("PlayerDeath");
        gameOverPanel.SetActive(true);

    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}