using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public float jumpforce;

    public Text score;

    private int scoreValue = 0;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
          {
             Application.Quit();
          } 
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse); 
            }
        }
    }
    
}