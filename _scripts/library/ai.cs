/*
 ************************************************
 * Name: ai.cs
 * Updated: 10/23/2017
 * Author: Sean Francis
 * Description: Static Class with Functions for
 *              AI Behavior.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ai {

	/// <summary>
	/// Find the position of Target given the Target Game Object.
	/// </summary>
	/// <returns>The Current Position of target.</returns>
	/// <param name="target">The GameObject Which the AI Wants to Find</param> 
	public static Vector3 findTarget(GameObject target){

		return target.transform.position;

	}

	/// <summary>
	/// Determine if One Vector is Close Enough to Another.
	/// </summary>
	/// <returns>True if the Vectors are Close Enough, False if Not.</returns>
	/// <param name="start">The Starting Position of the Check</param>
	/// <param name="end">The Ending Position of the Check</param>
	/// <param name="acceptibleDistance">How Close Do the Vectors Have to Be to Return True</param>
	public static bool closeEnough(Vector3 start, Vector3 end, float acceptibleDistance){

		if (Vector3.Distance (start, end) <= acceptibleDistance) {
		
			return true;
		
		} else {

			return false;

		}

	}
		
	/// <summary>
	/// Determine If Two Game Objects are Close Enough.
	/// </summary>
	/// <returns>True if the Objects are Close Enough, False if Not.</returns>
	/// <param name="start">The Starting Object of the Check</param>
	/// <param name="end">The Ending Object of the Check</param>
	/// <param name="acceptibleDistance">How Close Do the Objects Have to Be to Return True</param>
	public static bool closeEnough(GameObject start, GameObject end, float acceptibleDistance){

		if (Vector3.Distance (start.transform.position, end.transform.position) <= acceptibleDistance) {

			return true;

		} else {

			return false;

		}

	}
		
	/// <summary>
	/// Determine If Two Vector Axies are Close Enough. NEEDS TESTING!!
	/// </summary>
	/// <returns>True if the Objects are Close Enough, False if Not.</returns>
	/// <param name="start">The Starting Axis of the Check</param>
	/// <param name="end">The Ending Axis of the Check</param>
	/// <param name="acceptibleDistance">How Close Do the Axies Have to Be to Return True</param>
	public static bool closeEnough(float start, float end, float acceptibleDistance){

		if (Mathf.Abs ((start - end)) <= acceptibleDistance) {

			return true;

		} else {

			return false;

		}

	}

	/// <summary>
	/// Determine if One Vector is Far Enough Away from Another.
	/// </summary>
	/// <returns>True if the Vectors are Far Enough Away, False if Not.</returns>
	/// <param name="start">The Starting Position of the Check</param>
	/// <param name="end">The Ending Position of the Check</param>
	/// <param name="acceptibleDistance">How Far Do the Vectors Have to Be to Return True</param>
	public static bool farEnough(Vector3 start, Vector3 end, float acceptibleDistance){

		if (Vector3.Distance (start, end) >= acceptibleDistance) {

			return true;

		} else {

			return false;

		}

	}

	/// <summary>
	/// Determine If Two Game Objects are Far Enough Away from Each Other.
	/// </summary>
	/// <returns>True if the Objects are Far Enough Away, False if Not.</returns>
	/// <param name="start">The Starting Object of the Check</param>
	/// <param name="end">The Ending Object of the Check</param>
	/// <param name="acceptibleDistance">How Far Do the Objects Have to Be to Return True</param>
	public static bool farEnough(GameObject start, GameObject end, float acceptibleDistance){

		if (Vector3.Distance (start.transform.position, end.transform.position) >= acceptibleDistance) {

			return true;

		} else {

			return false;

		}

	}

	/// <summary>
	/// Determine If Two Vector Axies are Far Enough Away from Each Other. NEEDS TESTING!!
	/// </summary>
	/// <returns>True if the Objects are Far Enough Away, False if Not.</returns>
	/// <param name="start">The Starting Axis of the Check</param>
	/// <param name="end">The Ending Axis of the Check</param>
	/// <param name="acceptibleDistance">How Far Do the Axies Have to Be to Return True</param>
	public static bool farEnough(float start, float end, float acceptibleDistance){

		if (Mathf.Abs ((start - end)) >= acceptibleDistance) {

			return true;

		} else {

			return false;

		}

	}

}
