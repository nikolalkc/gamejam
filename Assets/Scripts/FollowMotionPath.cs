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
    float speedFactor = 0;
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
	
	
	void FixedUpdate()
	{
        SetMovement();
        MoveStep();


	}
    void MoveStep()
    {
        if (movement == Movement.Dynamic)
        {
            uv += ((speed / motionPath.length) * Time.fixedDeltaTime) + speedFactor;			// This gets you uv amount per second so speed is in realworld units
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

    void SetMovement()
    {
        int thisObjectIndexInList = stackControlRef.snakeStack.IndexOf(gameObject);
        int listCount = stackControlRef.snakeStack.Count;
        movement = Movement.Dynamic;
/*        for (int i = thisObjectIndexInList; i < listCount; i++)
        {

           if (stackControlRef.snakeStack[i].tag == "emptyObject") //ide do i-1 zato sto je 0-indexed govno
            {
                movement = Movement.Static;
                break;
            }
        }*/
        foreach (GameObject g in stackControlRef.snakeStack)
        {
            if (stackControlRef.snakeStack.IndexOf(g) >= thisObjectIndexInList)
            {
                if (g.tag == "emptyObject")
                {
                    movement = Movement.Static;
                    break;
                }
            }
        }


    }
	
}
