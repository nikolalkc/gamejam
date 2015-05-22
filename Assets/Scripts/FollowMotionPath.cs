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
	
	void Start()
	{
		stackControlRef = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
		lookVector = GameObject.FindGameObjectWithTag("lookVector").GetComponent<Transform>();
        motionPath = GameObject.FindGameObjectWithTag("path").GetComponent<MotionPath>();
		uv = startPosition;
		if (motionPath == null)
			enabled = false;
	}

	public bool IsDynamic() {
		snakeElementControl ElementProperties = gameObject.GetComponent<snakeElementControl>();
		int elementIndex = ElementProperties.thisElementIndex;
		bool isDynamic = true;
		int stackCount = stackControlRef.snakeStack.Count;
		int lastCreatedElementIndex = stackControlRef.snakeStack[stackCount].GetComponent<snakeElementControl>().thisElementIndex;
		for (int i = elementIndex; i < lastCreatedElementIndex; i++) {
			print ("StackCOunt:" + " " + stackCount + " i:" + i);
			if (stackControlRef.snakeStack[i].tag == "emptyObject") {
				isDynamic = false;
				break;
			}
		}
		return isDynamic;

	}
	
	void Update()
	{
		bool thisObjectIsDynamic = IsDynamic();
		if (thisObjectIsDynamic) {
			uv += ((speed / motionPath.length) * Time.fixedDeltaTime) + speedFactor;			// This gets you uv amount per second so speed is in realworld units
		}
		if (loop)
			uv = (uv<0?1+uv:uv) %1;
        else if (uv > 1)
        {
            enabled = false;
			stackControlRef.snakeStack.Remove(gameObject);
			Destroy(gameObject);
        }
		Vector3 pos = motionPath.PointOnNormalizedPath(uv);
		Vector3 norm = motionPath.NormalOnNormalizedPath(uv);
		
		 transform.position = pos;
		 transform.forward = speed >0?norm:-norm;

		//soulution one, fixed angle
		//cameraPosition = lookVector.position;
		//transform.right =-cameraPosition;

		cameraPosition = lookVector.position;
		Vector3 targetPosition = speed>0? pos+norm:pos-norm;
		transform.LookAt(targetPosition, cameraPosition);

	}
    void OnMouseDown()
    {
       // speedFactor += 0.001f;
      //  print("UV:"); print(uv);
     //   Destroy(gameObject);
    }
	
}
