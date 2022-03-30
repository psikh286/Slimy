using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour
{
	public static bool can_move = true;	
	private int step_count = 0;		
	private List<Vector3> directions = new List<Vector3>() {Vector3.right, Vector3.left, Vector3.forward, Vector3.back};
	private List<int> path = new List<int>() {2, 2};


	private void Update()
	{
		if (can_move && Input.GetKeyDown("space"))
		{
			can_move = false;
			int _path = path[step_count];
			transform.position += directions[_path];
			step_count++;
			can_move = true;
		}
	}

	
}
