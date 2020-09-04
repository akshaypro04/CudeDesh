using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rd;
    Transform gunHolder;
    Transform indicator;

    float speed;
    int canJump;
    bool jump;
    float fireTime = 0;
    float ReFiretimeLimit = 0.15f;
    bool shoot;
    float movingSpeed = 0.22f;
    float WhileJumpSpeed = 0.28f;

    Vector3 squashScale;
    Vector3 defaultScale;
    Vector3 velSquash;
    public CudeType role;

    [SerializeField] Transform PlayerBody;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject jumpEffect;
    PlayerInput playerInput
    {
        get
        {
            return GameManager.instances.playerInput;
        }
    }


    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        gunHolder = GameObject.Find("GunHolder/GunShoter").GetComponent<Transform>();
        indicator = GameObject.Find("IndicatorHolder").GetComponent<Transform>();
        defaultScale = transform.localScale;
        squashScale = defaultScale - new Vector3(0, 0.3f, 0);
        speed = movingSpeed;
    }

    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        indicator.transform.localEulerAngles = -rot;

        if (GameManager.instances.getGamePaused())
            return;

        if (!GameManager.instances.getPlayerAlive())
            return;

        PlayerMove();
        PlayerJump();
        playerShoot();
        PerfectJump();
        GameManager.instances.SetPlayerPos(transform);
    }

    void PlayerMove()
    {
        if (playerInput.Move != 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x + playerInput.Move, transform.position.y, 0), speed);
    }

    void PlayerJump()
    {
        if ((playerInput.jump || jump) && canJump < 2)
        {
            speed = WhileJumpSpeed;
            GameManager.instances.PlaySfx("jump");
            PlayerBody.transform.localScale = Vector3.SmoothDamp(transform.localScale, squashScale, ref velSquash, 0.01f);
            rd.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);                // jump force
            canJump++;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
            jump = false;
        }
    }

    void PerfectJump()
    {
        if (rd.velocity.y < 0)
        {
            PlayerBody.transform.localScale = defaultScale;
            rd.velocity += Vector2.up * Physics2D.gravity.y * (2f) * Time.deltaTime;
            speed = movingSpeed;
        }
    }

    void playerShoot()
    {
        fireTime += Time.deltaTime;
        if (playerInput.fire1 || shoot)
        {
            shoot = false;
            Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground" || col.gameObject.tag == "Enemy")
        {
            canJump = 0;
        }
    }

    void Shoot()
    {
        if(ReFiretimeLimit < fireTime)
        {
            GameManager.instances.PlaySfx("playerShoot");
            Instantiate(Bullet, gunHolder.position, gunHolder.rotation);
            fireTime = 0;
        }

    }

    public void PlayerJumpUI()
    {
        jump = true;
    }

    public void PlayerShootUI()
    {
        shoot = true;
    }
}
