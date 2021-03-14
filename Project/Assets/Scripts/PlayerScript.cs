using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MobBehaviour
{
    private new AudioSource audio;
    [SerializeField]
    private AudioClip shotSound;

    private MobBehaviour mobBehaviour;
    private Transform shootPoint;
    private Transform spriteTransform;
    private Vector3 direction;
    [SerializeField]
    private LayerMask layerMask;

    private bool isMovingUp;
    private bool isMovingLeft;
    private bool isMovingRigth;
    private bool isMovingDown;

    private float damage = 40f;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        spriteTransform = transform.Find("Sprite").transform;
        shootPoint = transform.Find("Sprite/ShootPoint").transform;
        mobBehaviour = GetComponent<MobBehaviour>();
    }
    private void Update()
    { 
        Shoot();
        LookAtMouse();
        Movement();
    }
    private void FixedUpdate()
    {
        ObstacleCheck();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) && isMovingUp)
        {
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y + speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A) && isMovingLeft)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                                             transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.D) && isMovingRigth)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                                             transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.S) && isMovingDown)
        {
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y - speed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(20);
            print(hp);
        }

    }
    private void LookAtMouse()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteTransform.rotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
    }
    private void Shoot()
    {
        Vector3 targetPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(shotSound);
            RaycastHit2D raycastHit = Physics2D.Raycast(shootPoint.position, direction, Vector3.Distance(shootPoint.position, targetPosition));
            if (raycastHit.collider != null)
            {
                if (raycastHit.collider.gameObject.tag == "Enemy")
                {
                    MobBehaviour mob = raycastHit.collider.gameObject.GetComponent<MobBehaviour>();
                    mob.GetDamage(damage);
                }
            }
            Debug.DrawRay(shootPoint.position, direction, Color.red);
        }
    }
    private void ObstacleCheck()
    {
        RaycastHit2D raycastHitUp = Physics2D.Raycast(transform.position, transform.up, 0.2f, layerMask);
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(transform.position, -transform.right, 0.2f, layerMask);
        RaycastHit2D raycastHitRigth = Physics2D.Raycast(transform.position, transform.right, 0.2f, layerMask);
        RaycastHit2D raycastHitDown = Physics2D.Raycast(transform.position, -transform.up, 0.2f, layerMask);

        if (raycastHitUp.collider == null)
        {
            isMovingUp = true;
            Debug.DrawRay(transform.position, transform.up, Color.blue);
        }
        else
            isMovingUp = false;
        if (raycastHitLeft.collider == null)
        {
            isMovingLeft = true;
            Debug.DrawRay(transform.position, -transform.right, Color.blue);
        }
        else
            isMovingLeft = false;
        if (raycastHitRigth.collider == null)
        {
            isMovingRigth = true;
            Debug.DrawRay(transform.position, transform.right, Color.blue);
        }
        else
            isMovingRigth = false;
        if (raycastHitDown.collider == null)
        {
            isMovingDown = true;
            Debug.DrawRay(transform.position, -transform.up, Color.blue);
        }
        else
            isMovingDown = false;
    }
}