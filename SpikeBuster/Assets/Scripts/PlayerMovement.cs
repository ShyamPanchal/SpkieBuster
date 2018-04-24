using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    float vertical, horizontal;
    public int lives;
    public Text live;
    public float speed;
    public GameObject endP1;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        //lives = 3;
        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives",3);
        if(lives == 0)
        {
            lives = 3;
        }
        live.text = "Lives: " + lives + "  ";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    public void PlayerDead()
    {
        lives = lives - 1;

        live.text = "Lives: " + lives+"  ";
        PlayerPrefs.SetInt("Lives",lives);
        if(lives <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.position = new Vector3(-3.5f, 0.5f, 0f);
            //endP1.GetComponent<Collider2D>().isTrigger = true;
            //Application.LoadLevel(Application.loadedLevel);
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
