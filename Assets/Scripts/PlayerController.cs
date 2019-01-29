using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private enum EnumDirection : int
    {
        Left = 0,
        Right = 1,
        Upward = 2,
        Downward = 3
    }

    public int health;
    public int maxHealth = 3;
    public float speed = 10f;

    public Rigidbody2D rb;
    public Animator animator;

    private EnumDirection faceSide;
    private bool _isMoving;

    public static PlayerController instance;
    public GameObject cameraZone;

    private bool accelaration = false;

    private void Start()
    {
        instance = this;
        health = maxHealth;
        if (PlayerPrefs.HasKey("Gyro"))
        {
            accelaration = PlayerPrefs.GetInt("Gyro") == 1;
        }
    }

    public void Damage(int amount)
    {
        Handheld.Vibrate();
        health -= amount;
        UI.instance.UpdateHealthUi();
        
        //Death process
        if (health > 0) return;
        Time.timeScale = 0.0f;
        UI.instance.ShowDeathScreen();

        var highscore = Score.instance.score;
        if (PlayerPrefs.HasKey("Last"))
        {
            var last = PlayerPrefs.GetInt("Last");
            highscore = Score.instance.score > last ? Score.instance.score : last;
        }

        PlayerPrefs.SetInt("Last", highscore);
    }

    public void CamShoot()
    {
        animator.Play("CamShoot 1");
    }

    public void CamZoneEnable()
    {
        //cameraZone.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            CamShoot();

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (Math.Abs(SimpleInput.GetAxis("Vertical")) > 0f)
        {
            vertical = SimpleInput.GetAxis("Vertical");
        }

        if (Math.Abs(SimpleInput.GetAxis("Horizontal")) > 0f)
        {
            horizontal = SimpleInput.GetAxis("Horizontal");
        }

        if (accelaration)
        {
            vertical = Input.acceleration.y * 1.25f;
            horizontal = Input.acceleration.x * 1.25f;
        }

        _isMoving = Math.Abs(vertical) > 0f || Math.Abs(horizontal) > 0f;
        var camZoneRotation = cameraZone.transform.eulerAngles;

        if (horizontal < 0f)
        {
            faceSide = EnumDirection.Left;
            transform.eulerAngles = new Vector2(0f, 180f);
            camZoneRotation.z = -270f;
        }
        else if (faceSide != EnumDirection.Right && horizontal > 0f)
        {
            faceSide = EnumDirection.Right;
            transform.eulerAngles = new Vector2(0f, 0f);
            camZoneRotation.z = -90f;
        }

        if (vertical < -0.3f)
        {
            faceSide = EnumDirection.Downward;
            camZoneRotation.z = -180f;
        }
        else if (faceSide != EnumDirection.Upward && vertical > 0.3f)
        {
            faceSide = EnumDirection.Upward;
            camZoneRotation.z = 0f;
        }

        cameraZone.transform.eulerAngles = camZoneRotation;

        animator.SetBool("HorizontalMoving",
            _isMoving && (faceSide == EnumDirection.Right || faceSide == EnumDirection.Left));
        animator.SetBool("VerticalMoving",
            _isMoving && (faceSide == EnumDirection.Upward || faceSide == EnumDirection.Downward));
        animator.SetInteger("Side", (int) faceSide);

        rb.velocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
    }
}