using UnityEngine;

[RequireComponent(typeof(Animator))]
public class S_AnimController : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    Animator animator;

    string[] directions = new string[8] { "S_Forward", "S_FLeft", "S_Left", "S_BLeft", "S_Backward", "S_BRight", "S_Right", "S_FRight" };
    string[] idleDirs = new string[8] { "S_FIdle", "S_FLIdle", "S_LIdle", "S_BLIdle", "S_BIdle", "S_BRIdle", "S_RIdle", "S_FRIdle" };
    string[] jumpDirs = new string[4] { "S_FJump", "S_LJump", "S_BJump", "S_RJump" };

    Vector3 lastDir;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (sonic.IsJumping)
        {
            animator.Play("S_FJump");
        }
        else 
        {
            if (sonic.Velocity != Vector3.zero)
            {
                lastDir = sonic.Velocity;
                animator.speed = Mathf.Clamp(sonic.Acceleration + 0.30f, 0.0f, 1.0f);
                animator.Play(DirectionGiver(sonic.Velocity, directions));
            }
            else
            {
                animator.speed = 1.0f;
                animator.Play(DirectionGiver(lastDir, idleDirs));
            }
        }
    }

    string DirectionGiver(Vector3 v, string[] dirs)
    {
        int angle = 0, dir = 0;
        Vector2 vector = new Vector2(v.x, v.z);
        int step = 360 / dirs.Length;
        angle = (int)Vector2.SignedAngle(Vector2.up, vector);

        if (angle < 0)
        {
            angle += 360;
        }

        dir = angle / step;

        return dirs[dir];
    }
}
