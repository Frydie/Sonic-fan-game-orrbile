using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class S_Jump : MonoBehaviour
{
    //Lasciate ogni speranza o voi che entrate.

    [SerializeField]
    Sonic sonic;

    float distToGround, minHeight, jumpTime = 0.1f, maxUpTime = 1.0f, slowDown = 0.0f, jumpKey = 0.0f;
    Vector3 jump;
    CharacterController controller;
    CapsuleCollider capsule;
    bool noAutoJump = true;
    AudioSource source;

    void Start()
    {
        distToGround = capsule.bounds.extents.y; //La distanza di sonic dal terreno.
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        capsule = GetComponent<CapsuleCollider>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Fix rapidino per l'auto-jump
        if (jumpKey != 0.0f)        
        {
            noAutoJump = true;
        }
        else
        {
            noAutoJump = false;
        }

        jumpKey = Input.GetAxisRaw("Jump");


        if (!noAutoJump && jumpKey == 1.0f && sonic.IsGrounded)
        {
            sonic.IsJumping = true;
            source.clip = sonic.JumpSoundEffect;
            source.Play();
        }

        if (sonic.IsJumping)
        {
            if (jumpKey == 0.0f)
            {
                sonic.StartFalling = true;
            }

            if (sonic.StartFalling)
            {
                jumpTime += 0.1f;
                slowDown = jumpTime / minHeight;
            }

            jump = new Vector3(0.0f, maxUpTime - slowDown, 0.0f);

            if (controller.transform.position.y > minHeight && !sonic.StartFalling)
            {
                maxUpTime = sonic.JumpMaxHeight;
                sonic.StartFalling = true;
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(jump * sonic.JumpPower * Time.fixedDeltaTime);

        if (Physics.Raycast(controller.transform.position, Vector3.down, distToGround + 0.01f))
        {
            minHeight = controller.transform.position.y + sonic.JumpMinHeight;
            jumpTime = 0.1f;
            maxUpTime = 1.0f;
            slowDown = 0.0f;
            sonic.IsGrounded = true;
            sonic.StartFalling = false;
            sonic.IsJumping = false;
        }
        else
        {
            sonic.IsGrounded = false;
        }
    }
}