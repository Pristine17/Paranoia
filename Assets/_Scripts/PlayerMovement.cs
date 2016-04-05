using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator anim;
    float camRayLength=100f;
    int floorMask;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h,float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast(camRay,out floorHit,camRayLength,floorMask))
        {
            Vector3 mouseToPlayer = floorHit.point - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(mouseToPlayer);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h,float v)
    {
        bool walking = (h != 0 || v != 0);
        anim.SetBool("IsWalking", walking);
    }
}
