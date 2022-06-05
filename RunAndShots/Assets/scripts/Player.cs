using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float moveInput;

    [SerializeField]
    public Button RestartButton;
    
    [SerializeField] 
    public Button MenuButton;

    [SerializeField] 
    private Text ScoreText;

    [SerializeField]
    private Transform feetPos;
    
    [SerializeField]
    private float checkRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField] 
    private Transform ShotPos;

    [SerializeField] 
    private GameObject bullet;
    
    [SerializeField]
    private float startTimeBtwShots;

    [SerializeField] 
    private float offset;

    private Rigidbody2D Rigid;

    private float timeBtwShots;
    
    private int Score;

    private int OldScore;

    private bool isGrounded;

    private void Awake()
    {
        Time.timeScale = 1;
        
        Rigid = GetComponent<Rigidbody2D>();

        Rigid.freezeRotation = true;

        OldScore = PlayerPrefs.GetInt("Score",OldScore);

        StartCoroutine(ScoreUpdate());
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        Rigid.velocity = new Vector2(moveInput * speed, Rigid.velocity.y);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        ShotPos.rotation = Quaternion.Euler(0f,0f,rotZ + offset);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            Destroy(enemy.gameObject);

            gameObject.SetActive(false);
            
            RestartButton.gameObject.SetActive(true);
            MenuButton.gameObject.SetActive(true);
            
            StopCoroutine(ScoreUpdate());
            
            if (Score >= OldScore)
            {
                PlayerPrefs.SetInt("Score",Score);
            }

            Time.timeScale = 0;
        }
    }

    private IEnumerator ScoreUpdate()
    {
        while (true)
        {
            Score++;

            ScoreText.text = "Score - " + Score;
            
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Rigid.velocity = Vector2.up * jumpForce;
        }
        
        if (Input.GetMouseButton(0) && timeBtwShots <= 0)
        {
            Instantiate(bullet,ShotPos.position,ShotPos.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
