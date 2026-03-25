
//using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    private float xMove;
    private float xVelocity;
    public float jumpSpeed;
    private Rigidbody2D rb;

    private bool jumpFlag = false;

    public LayerMask ground;

    public GameObject meleeAttack;

    private float facingDirection;

    private float attackOffset = 0.8f;

    public float meleeDuration = 0.025f;

    private float timeElapsedSinceMelee = 0;
    private bool meleeTrigger = false;
    public GameObject bulletPrefab;
    
    private bool powerOn;

    public Color powerRed;
    public Color powerBlue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;

    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFlag = true;
        }
        if (xMove != 0)
        {
            facingDirection = xMove;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            MeleeAttack();

        }
        if (meleeTrigger)
        {
            if (timeElapsedSinceMelee < meleeDuration)
            {
                timeElapsedSinceMelee += Time.deltaTime;
            }
            else
            {
                meleeAttack.SetActive(false);
                timeElapsedSinceMelee = 0;
                meleeTrigger = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RangedAttack();

        }

    }



    private void FixedUpdate()
    {
        xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;

        }
    }

    private void MeleeAttack()
    {
        meleeTrigger = true;
        meleeAttack.SetActive(true);
        meleeAttack.transform.localPosition = new Vector3(attackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);
    }

    public void PowerUp()
    {
        powerOn =! powerOn;
    }

    private void RangedAttack()
    {
        Vector3 pos = new Vector3(transform.position.x + (attackOffset * facingDirection), transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.GetComponent<Bullet>().direction = new Vector2(facingDirection, 0);

        if (powerOn)
        {
            
        }

    }


    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist, ground);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUp>() != null)
        {
            collision.GetComponent<PowerUp>().ApplyEffect();
        }

    }
    public void ApplyBulletChange(Color color)
    {
        
    }
}
