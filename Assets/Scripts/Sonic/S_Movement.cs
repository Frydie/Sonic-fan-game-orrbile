using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class S_Movement : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    float xAxis;
    float zAxis;
    float x = 0.0f, z = 0.0f;
    bool hasPlayed = true;
    bool hasStopped = true;
    CharacterController controller;
    Vector3 prevDir;

    AudioSource source;

    void Start()
    {
        sonic.Velocity = Vector3.zero;
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        prevDir = sonic.Velocity;
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        sonic.Velocity = Vector3.ClampMagnitude(new Vector3(xAxis, 0.0f, zAxis), 1.0f);

        if (hasStopped && (xAxis != 0.0f || zAxis != 0.0f) && !IsOppositeDirection(prevDir, sonic.Velocity))
        {
            hasPlayed = false;
            sonic.Acceleration += 0.01f;
            sonic.Acceleration = Mathf.Clamp(sonic.Acceleration, 0.0f, 1.0f);
        }
        else
        {
            hasStopped = false;
            if (!hasPlayed && !sonic.IsJumping && sonic.Acceleration > 0.8f)
            {
                source.clip = sonic.ShoeBreak;
                source.Play();
                hasPlayed = true;
            }
            sonic.Acceleration -= 0.05f;
            sonic.Acceleration = Mathf.Clamp(sonic.Acceleration, 0.0f, 1.0f);
            if(sonic.Acceleration == 0.0f)
            {
                hasStopped = true;
            }
            else
            {
                sonic.Velocity = prevDir;
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(sonic.Velocity * sonic.MaxSpeed * sonic.Acceleration * Time.fixedDeltaTime);
    }

    bool IsOppositeDirection(Vector3 dirA, Vector3 dirB)
    {
        bool isOpposite = new Vector3(dirA.x + dirB.x, dirA.y + dirB.y, dirA.z + dirB.z) == Vector3.zero ? true : false;
        return isOpposite;
    }
}
