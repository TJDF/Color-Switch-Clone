using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public AudioManager audioManager;
    public GameObject panel;
    public Text txtPointsPanel;
    public Text txtPointsGame;

    [SerializeField] GameObject deathParticles;
    [SerializeField] float jumpForce;
    int points;
    bool jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        points = 0;
        RandomColorFunc();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
            audioManager.JumpAudioPlay();
        }
    }

    [SerializeField] Color[] color;

    string currentColor;

    void RandomColorFunc()
    {
        int n = Random.Range(0 , color.Length);

        if(n == 0)
        {
            sr.color = color[0];
            currentColor = "Pink";
        }
        else if(n == 1)
        {
            sr.color = color[1];
            currentColor = "Green";
        }
        else if(n == 2) 
        {
            sr.color = color[2];
            currentColor = "Blue";
        }
        else
        {
            sr.color = color[3];
            currentColor = "Orange";
        }
    }

    void ChosenColorFunc()
    {
        int n = Random.Range(0, 2);

        if (n == 0)
        {
            sr.color = color[2];
            currentColor = "Blue";
        }
        else if (n == 1)
        {
            sr.color = color[1];
            currentColor = "Green";
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ChangeColor")
        {
            RandomColorFunc();
            audioManager.ChangeColorAudioPlay();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ChangeColorPreDefined")
        {
            ChosenColorFunc();
            audioManager.ChangeColorAudioPlay();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Points")
        {
            points++;
            audioManager.PointAudioPlay();
            txtPointsGame.text = points.ToString();
            PointsScript pointsScript = collision.GetComponent<PointsScript>();
            pointsScript.SpawnNextObstacle();
            Destroy(collision.gameObject);
        }
        else if(collision.tag != currentColor)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            audioManager.LoseAudioPlay();
            panel.SetActive(true);
            txtPointsPanel.text = points.ToString();
            Destroy(gameObject);
        }
    }
}
