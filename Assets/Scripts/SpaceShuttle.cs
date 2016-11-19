using UnityEngine;
using System.Collections;

public class SpaceShuttle : MonoBehaviour {

	public GameObject Target;
	public float SpeedModifyer = 1.0f;
	public float ScaleModifyer = 1.0f;

	private float InitialDiffernece;
	private Vector3 InitialScale;
	private Vector3 StartPosition;
	private float Timer = 0;
	// Use this for initialization
	void Start () {
		StartPosition = transform.position;
		InitialScale = transform.localScale;
		InitialDiffernece = GetDistance(transform.position, Target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		float Speed = 
				SpeedModifyer 
			*	Time.deltaTime
			*	(Vector2.Distance(transform.position, Target.transform.position) / 100);
		transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed);

		float Change = GetDistance(transform.position, Target.transform.position) / InitialDiffernece;
		transform.localScale = InitialScale * Change;
	}

	private float GetDistance(Vector3 Start, Vector3 End) {
		float distance = Vector2.Distance(Start, End);
		distance = distance * ScaleModifyer;
		Vector3 difference = Target.transform.position - transform.position;
		difference = difference.normalized * distance;

		return difference.magnitude;
	}
}
