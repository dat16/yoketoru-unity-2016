using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public float spawnY = 5.5f;
	public float spawnX = 9f;
	public int ITEM_MAX = 8;
	public int ENEMY_MAX = 8;
	public GameObject prefItem;
	public GameObject prefEnemy;

	// Use this for initialization
	void Start () {
		// アイテム数を設定する
		CItem.SetCount(ITEM_MAX);
		for (int i = 0; i < ITEM_MAX; i++) {
			// 出現座標
			Vector3 pos = new Vector3 (
				Random.Range (-spawnX, spawnX),
				Random.Range (-spawnY, spawnY)+Camera.main.transform.position.y,
				0f);
			// 出現(prefItemを、posの場所に、回転させずに登場)
			Instantiate(prefItem, pos, Quaternion.identity);
		}
		for (int i = 0; i < ENEMY_MAX; i++) {
			// 出現座標
			Vector3 pos = new Vector3 (
				Random.Range (-spawnX, spawnX),
				Random.Range (-spawnY, spawnY)+Camera.main.transform.position.y,
				0f);
			// 出現(prefItemを、posの場所に、回転させずに登場)
			Instantiate(prefEnemy, pos, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene ("GameOver");
		}
		if (Input.GetMouseButtonDown(1)) {
			SceneManager.LoadScene ("Clear");
		}
		*/
	}
}
