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
	public float timeBetweenAttacks = 3f;
	float timer = 0;

	private bool doubleTheFun= false;

	// Use this for initialization
	void Start () {
		timer = timeBetweenAttacks;
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
			if (doubleTheFun) {
				//pick a random skill
				s = attacks [(int)(Random.value * attacks.Length)];
				//cast the spell
				s.Cast ();
				Debug.Log ("Speel cast: " + s);
			}
			timer = timeBetweenAttacks;
		}
	}

	public void NotifyCapture()
	{
		rings--;

		switch (rings) {
		case 4:
			//increment skill rate by 25%
			timeBetweenAttacks=2f;
			break;
		case 3:
			//spawn a wave of enemies
			break;
		case 2:
			//send two skills at a time
			doubleTheFun = true;
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
