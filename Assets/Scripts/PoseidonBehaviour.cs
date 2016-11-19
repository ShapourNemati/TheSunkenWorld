using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PoseidonBehaviour : MonoBehaviour {


	public class TestSkill : ISkill {
		public void Cast()
		{
			Debug.Log ("A spell is being cast");
		}
	}

	int rings = 5;

	public GameObject [] attacksObjs;
	public ISkill[] attacks;
	public const float TIME_BETWEEN_ATTACKS = 2f;
	float timer = 0;

	// Use this for initialization
	void Start () {
		timer = TIME_BETWEEN_ATTACKS;
		attacks = new ISkill[attacksObjs.Length];
		for (int i = 0; i < attacksObjs.Length; i++) {
			attacks [i] = attacksObjs [i].GetComponent <ISkill> ();	
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			//pick a random skill
			ISkill s = attacks [(int)(Random.value * attacks.Length)];
			//cast the spell
			s.Cast ();
			Debug.Log ("Speel cast: " + s);
			timer = TIME_BETWEEN_ATTACKS;
		}
	}

	public void NotifyCapture()
	{
		rings--;

		switch (rings) {
		case 4:
			//increment skill rate
			break;
		case 3:
			//spawn a wave of enemies
			break;
		case 2:
			//send two skills at a time
			break;
		case 1:
			//continuous spawn of enemies
			break;
		case 0:
			//You won!
			break;
		}
	}
}
