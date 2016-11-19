using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TestScriptJonas : MonoBehaviour {
	public GameObject[] attacksObjs;
	ISkill[] attacks;
	// Use this for initialization

	void Start () {
		attacks = new ISkill[attacksObjs.Length];
		for (int i = 0; i < attacksObjs.Length; i++) {
			attacks[i] = attacksObjs[i].GetComponent<ISkill>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		int Number;
		if(int.TryParse(Input.inputString, out Number)) {
			ISkill s = attacks[Number];
			s.Cast();
		}
	}
}
