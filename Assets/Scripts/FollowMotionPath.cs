using UnityEngine;
using System.Collections;

public class FollowMotionPath : MonoBehaviour
{
    StackController stackControlRef;
    public MotionPath motionPath;
    public float startPosition;
    float speed = game.globalSnakeSpeed;									// Realworld units per second you want your object to travel
    public bool loop;
    Transform lookVector;
    Vector3 cameraPosition;
    public float uv;
    public float speedFactor = 1;
    public enum Movement { Static, Dynamic };
    public Movement movement;

    void Start()
    {
        stackControlRef = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
        movement = Movement.Dynamic;
        lookVector = GameObject.FindGameObjectWithTag("lookVector").GetComponent<Transform>();
        motionPath = GameObject.FindGameObjectWithTag("path").GetComponent<MotionPath>();
        uv = startPosition;
        if (motionPath == null)
            enabled = false;
        MoveStep();
    }


    void Update()
    {
        SetMovement();
        if (movement == Movement.Dynamic)
        {
            MoveStep();
        }


    }
    void MoveStep()
    {

        uv += ((speed / motionPath.length) * Time.deltaTime) * speedFactor;			// This gets you uv amount per second so speed is in realworld units
        if (loop)
            uv = (uv < 0 ? 1 + uv : uv) % 1;
        else if (uv > 1)
        {
            enabled = false;

            stackControlRef.snakeStack.Remove(gameObject);
            //   print(gameObject.name + " destroyed on PATH END.");
            Destroy(gameObject);
        }
        Vector3 pos = motionPath.PointOnNormalizedPath(uv);
        Vector3 norm = motionPath.NormalOnNormalizedPath(uv);

        transform.position = pos;
        transform.forward = speed > 0 ? norm : -norm;

        //soulution one, fixed angle
        if (gameObject.tag == "cube")
        {
            cameraPosition = lookVector.position;
            transform.forward = -cameraPosition;
        }

        //solutuion two, look at camera
        if (gameObject.tag == "emptyObject")
        {
            cameraPosition = lookVector.position;
            Vector3 targetPosition = speed > 0 ? pos + norm : pos - norm;
            transform.LookAt(targetPosition, cameraPosition);
        }




    }

    void SetStatic()
    {
        movement = Movement.Static;
    }

    void StartWiggle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Wiggle", true);
    }


    void SetDynamic()
    {
        movement = Movement.Dynamic;
    }
    void SetMovement()
    {
        int thisObjectIndexInList = stackControlRef.snakeStack.IndexOf(gameObject);
        Animator animator = gameObject.GetComponent<Animator>();
        movement = Movement.Dynamic;
        animator.SetBool("Static", false);
        animator.SetBool("Wiggle", false);
        foreach (GameObject g in stackControlRef.snakeStack)
        {
            if (stackControlRef.snakeStack.IndexOf(g) >= thisObjectIndexInList)
            {
                if (g.tag == "emptyObject")
                {
                    // movement = Movement.Static;

                    animator.SetBool("Static", true);
                    break;
                }
            }
        }


    }

}
