using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {
	private static BGMManager me = null; 
	// ゲームオブジェクトを永続化
	// @url http://qiita.com/srtkmsw/items/bf6a33d6bb2987c74936
	void Awake() {
		// 最初の1回のみ
		if (me == null) {
			me = this;
			Debug.Log ("awake");
			DontDestroyOnLoad (this);
			AudioSource src = GetComponent<AudioSource> ();
			src.Play ();
		} else {
			Debug.Log ("destroy");
			Destroy (this);
		}
	}
}
