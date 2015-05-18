using UnityEngine;
using System.Collections;

// The purpose of this class is to allow normalized position and direction (normal) lookup of an iTween curve
// It will respect the transform of the object its attached to... However scaling the object will result in the length of the curve being wrong

public class MotionPath : MonoBehaviour
{
	public int samples = 10;						// How many times to sample the curve per segment
	public Vector3[] controlPoints;				// The points in local space (they are translated by the localMatrix after evaluation
	public bool looping;
	AnimationCurve uvLUT;						// Curve that remaps uv values to a normalized length
	AnimationCurve xLUT;							// Normal X direction of the path
	AnimationCurve yLUT;							// Normal Y direction of the path
	AnimationCurve zLUT;							// Normal Z direction of the path
	
	public Vector3 centerPoint 					// This is used only in the editor script to place the length info on screen
	{
		get 
		{
			Vector3 accum = Vector3.zero;
			int len = controlPoints.Length;
			for (int i = 0; i < len; i++)
			{
				accum += controlPoints[i];
			}
			return new Vector3(accum.x / len, accum.y / len, accum.z / len);
		}
	}
	
	public float length {get {return iTween.PathLength(controlPoints);}}
	
	public void Init()
	{
		// Make sure there are at least two points in the controlPoints[]
		if (controlPoints == null || controlPoints.Length < 2)
			controlPoints = new Vector3[] {new Vector3(0,0,-5), new Vector3(0,0, 5)};
		
		// Build lookup tables (LUT)
		Rebuild();
	}
	
	void Start()
	{
		Init ();
	}
	
	/// <summary>
	/// Rebuild all Lookup tables for the path... This should be called when ever the samples number changes or any points are moved
	/// </summary>
	public void Rebuild()
	{
		// Scrap old curves
		uvLUT = new AnimationCurve();
		xLUT = new AnimationCurve();
		yLUT = new AnimationCurve();
		zLUT = new AnimationCurve();
		
		// Add known start and end points to uvLUT
		uvLUT.AddKey(0,0);
		uvLUT.AddKey(1,1);
		
		
		samples = Mathf.Max(samples, 2);												// Force samples to always be greater than 1
		float uvStepSize = (1.0f / (controlPoints.Length - 1)) / samples;		// This is how much we increase our iTween.PointOnPath amount by each evaluation
		
		float pathLength = length;															// Get length of path from iTween
		float distanceTraveled = 0;															// Keep track of actual distance traveled along the path
		float sampleUV = uvStepSize;														// Set initial sample point to uvStepSize, there is no need to sample position 0
		Vector3 sampleCurrent = controlPoints[0];									// Current point sampled
		Vector3 sampleLast = controlPoints[0];										// Previous point sampled - used to get distance and normal
		Vector3 normal = Vector3.forward;											// Normal from last point to current point
		
		while(sampleUV < 1)
		{
			sampleCurrent = iTween.PointOnPath(controlPoints, sampleUV); 			// Sample point from iTween
			distanceTraveled += Vector3.Distance(sampleLast, sampleCurrent);		// Increment distance traveled
			float factor = distanceTraveled / pathLength;										// Get percentage in actual distance that distanceTraveled = of pathLength
			uvLUT.AddKey(factor, sampleUV);														// Add key on Lookup table
			
			normal = (sampleCurrent - sampleLast).normalized;								// Normal from last sample point to current
			xLUT.AddKey(sampleUV, normal.x);														// Save each component of the normal to their own curves
			yLUT.AddKey(sampleUV, normal.y);
			zLUT.AddKey(sampleUV, normal.z);
			
			sampleUV += uvStepSize;																	// Increament sampleUV by uvStepSize
			sampleLast = sampleCurrent;																// Save current point as last
			
		}
		
		if (controlPoints[0] == controlPoints[controlPoints.Length-1])						// Check if first and last points are equal... if so make sure the normal LUTs loop as well
		{
			looping = true;
			sampleCurrent = iTween.PointOnPath(controlPoints, 1);
			normal = (sampleCurrent - sampleLast).normalized;
			xLUT.AddKey(0, normal.x);
			yLUT.AddKey(0, normal.y);
			zLUT.AddKey(0, normal.z);
			
			xLUT.AddKey(1, normal.x);
			yLUT.AddKey(1, normal.y);
			zLUT.AddKey(1, normal.z);
		}
		else
			looping = false;
		
	}
	
	/// <summary>
	/// Normalize a uv value for use with iTween
	/// </summary>
	public float NormalizedUV(float uv)
	{
		return uvLUT.Evaluate(uv);
	}
	
	/// <summary>
	/// Returns a position on the path... this is the default iTween behaviour
	/// </summary>
	public Vector3 PointOnPath(float uv)
	{
		return transform.localToWorldMatrix.MultiplyPoint(iTween.PointOnPath(controlPoints, uv));
	}
	
	/// <summary>
	/// Returns a position on the path normalized over its distance
	/// This allows for constant speed along a path
	/// </summary>
	public Vector3 PointOnNormalizedPath(float uv)
	{
		return transform.localToWorldMatrix.MultiplyPoint(iTween.PointOnPath(controlPoints, uvLUT.Evaluate(uv)));
	}
	
	/// <summary>
	/// Returns the normal of the path at a given uv
	/// This should be used with PointOnPath
	/// 	If used with PointOnNormalizedPath the normal will be from a different point on the path
	/// </summary>
	public Vector3 NormalOnPath(float uv)
	{
		Vector3 norm = new Vector3(xLUT.Evaluate(uv), yLUT.Evaluate(uv), zLUT.Evaluate(uv));
		return transform.localToWorldMatrix.MultiplyVector(norm);
	}
	
	/// <summary>
	/// Returns the normal of the path at a given normalized uv
	/// This should be used with PointOnNormalizedPath
	/// 	If used with PointOnPath the normal will be from a different point on the path
	/// </summary>
	public Vector3 NormalOnNormalizedPath(float uv)
	{
		float uvN = uvLUT.Evaluate(uv);
		Vector3 norm = new Vector3(xLUT.Evaluate(uvN), yLUT.Evaluate(uvN), zLUT.Evaluate(uvN));
		return transform.localToWorldMatrix.MultiplyVector(norm);
	}
	
	void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		iTween.DrawPath(controlPoints);
	/*	if (!UnityEditor.Selection.Contains(gameObject))
		{
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(controlPoints[0], .2f);
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(controlPoints[controlPoints.Length-1], .2f);
		}*/
		
	}

}
