using System;
using UnityEngine;
using UnityEngine.UI;

public class enemyAiController : MonoBehaviour
{
    [SerializeField] GameObject jumpEffect;
    Transform player;
    Rigidbody2D rd;

    float resentPos;
    public float speed = 2f;
    int jumpCount;
    bool canMove;
    bool isjumping;
    float readyJump = 1f;
    float preparJump;
    float squashTime = 0.01f;

    public float fieldOfImpact = 7f;
    public float squashSize;
    public float jumpForce;
    public LayerMask layer2Player;

    Vector3 squashScale;
    Vector3 defaultScale;
    Vector3 velSquash = Vector3.zero;
    public Transform HealthIndicator;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale;
        squashScale = new Vector3(transform.localScale.x, squashSize, 1);
        canMove = true;
        isjumping = true;
    }


    void Update()
    {
        if (!GameManager.instances.getPlayerAlive())
            return;

        if (HealthIndicator != null)
        {
            Vector3 rot = transform.eulerAngles;
            HealthIndicator.transform.localEulerAngles = -rot;
        }

        CheckPlayerPos();

        player = GameManager.instances.getPlayerPos();

        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }


        if (Mathf.Floor(transform.position.x) == Mathf.Floor(resentPos))
        {
            playerJump();
            PerfectJump();
        }

        resentPos = transform.position.x;

    }


    void playerJump()
    {
        preparJump += Time.deltaTime;

        if (readyJump < preparJump)
        {
            if (jumpCount < 2 && isjumping)
            {
                GameManager.instances.PlaySfx("jump");
                rd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);                                            
                transform.localScale = Vector3.SmoothDamp(transform.localScale, squashScale, ref velSquash, squashTime * Time.deltaTime);
                Instantiate(jumpEffect, transform.position, Quaternion.identity);
                preparJump = 0;
                jumpCount++;
                isjumping = false;
            }
        }
    }

    void PerfectJump()                                                      // automatic
    {
        if (rd.velocity.y < 0 && isjumping == false)
        {
            transform.localScale = defaultScale;
            rd.velocity += Vector2.up * Physics2D.gravity.y * (2f) * Time.deltaTime;
            isjumping = true;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }
    }

    void CheckPlayerPos()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layer2Player);

        foreach (Collider2D obj in objects)
        {

            if (obj.tag == "Player")
            {
                canMove = false;
                return;
            }
            else
            {
                canMove = true;
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

}
