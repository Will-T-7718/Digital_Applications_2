using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private CharacterInput controls; 
    private Vector3 velocity; 
    private Vector2 move; 

    private CharacterController controller;
    public ShootObjConScript ShootCon;
    public GunObjScriptable GunScript;

    public float moveSpeed = 6f; 
    public float jumpHeight = 24f; 
    public float gravity = -9.81f;

    public Transform ground; 
    public float distanceToGround = 0.4f; 
    public LayerMask groundMask;

    [SerializeField]private PlayerGunSelect GunSelect;
    [SerializeField]private AudioClip gunShotC;
    [SerializeField] private AudioClip walkingC;
    [SerializeField]private AudioClip JumpC;

    void Awake()
    {
        
        controls = new CharacterInput();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
        Grav();
        Jump();
        Shoot();
    }
    private void Shoot()
    {
        if (Mouse.current.leftButton.isPressed && GunSelect.ActiveGun != null)
        {
                GunSelect.ActiveGun.shoot();
                Debug.Log("shooting");
                SoundFX_Manager.instance.PlaySoundFXClip(gunShotC, transform, 1f);
        }
    }

    private void Grav()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(ground.position, distanceToGround, groundMask);
    }

    private void PlayerMovement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (controls.Player.Jump.triggered && isGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            SoundFX_Manager.instance.PlaySoundFXClip(JumpC, transform, 1f);
        }
    }



    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}
