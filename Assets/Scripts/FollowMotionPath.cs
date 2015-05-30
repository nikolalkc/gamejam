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
        MoveStep();


	}
    void MoveStep()
    {
        if (movement == Movement.Dynamic)
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
                transform.right = -cameraPosition;
            }

            //solutuion two, look at camera
            if (gameObject.tag == "emptyObject")
            {
                cameraPosition = lookVector.position;
                Vector3 targetPosition = speed > 0 ? pos + norm : pos - norm;
                transform.LookAt(targetPosition, cameraPosition);
            }
        }
    }

    void SetStatic()
    {
        movement = Movement.Static;
    }

    void SetDynamic()
    {
        movement = Movement.Dynamic;
    }
    void SetMovement()
    {
        int thisObjectIndexInList = stackControlRef.snakeStack.IndexOf(gameObject);
        int listCount = stackControlRef.snakeStack.Count;
        Animator animator = gameObject.GetComponent<Animator>();
        movement = Movement.Dynamic;
        animator.SetBool("Static", false);
        foreach (GameObject g in stackControlRef.snakeStack)
        {
            if (stackControlRef.snakeStack.IndexOf(g) >= thisObjectIndexInList)
            {
                if (g.tag == "emptyObject")
                {
                    // movement = Movement.Static;

                    animator.SetBool("Static",true);
                    break;
                }
            }
        }


    }
	
}
