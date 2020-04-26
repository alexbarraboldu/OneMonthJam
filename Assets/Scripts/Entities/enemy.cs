using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
	public Transform Objective;
	public float Speed;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float velocity = Speed * Time.deltaTime;
		Objective.position = SearchObjective();
		transform.position = Vector2.MoveTowards(transform.position, Objective.position, velocity);
	}

	Vector2 SearchObjective()
	{
		float lowestDistance = 99999;
		Vector2 position = Vector2.zero;
		//for (int i = 0; i < Manager.Instance.Core.Length; i++)
		//{
		//    if (Vector3.Distance(transform.position, Manager.Instance.Core[i].transform.position) < lowestDistance)
		//    {
		//        lowestDistance = Vector3.Distance(transform.position, Manager.Instance.Core[i].transform.position);
		//        position = Manager.Instance.Core[i].transform.position;
		//    }
		//}
		//if (Vector3.Distance(transform.position, RialMainCore.transform.position) < lowestDistance)
		//{
		//    lowestDistance = Vector3.Distance(transform.position, RialMainCore.transform.position);
		//    position = RialMainCore.transform.position;
		//}

		return position;
	}
}
