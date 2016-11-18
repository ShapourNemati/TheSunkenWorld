using UnityEngine;
using System.Collections;

public class OxygenManager : MonoBehaviour {

	public const float STARTING_OXYGEN = 100f;
	public const float OXYGEN_LOSS_PER_TIME = 2f;

	
	public float oxygen = STARTING_OXYGEN;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		oxygen -= OXYGEN_LOSS_PER_TIME * Time.deltaTime;
		if (oxygen <= 0) {
			//Something bad
		}

	}

	public bool PayOxygenCost(float amount)
	{
		if (oxygen < amount) {
			return false;
		} else {
			oxygen -= amount;
			return true;
		}

	}


}
