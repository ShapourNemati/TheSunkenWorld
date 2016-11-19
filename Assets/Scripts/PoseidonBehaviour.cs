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
			timer = TIME_BETWEEN_ATTACKS;
		}
	}
}
