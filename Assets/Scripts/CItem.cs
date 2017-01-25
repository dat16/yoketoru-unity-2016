using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CItem : MonoBehaviour {
	private static int iCount = 0;

	/**
	 * 指定の値をアイテム数として設定
	 */
	public static void SetCount(int count) {
		iCount = count;
	}

	/**
	 * 接触処理
	 */
	void OnCollisionEnter(Collision other) {
		// 相手のタグがプレイヤーか
		if (other.gameObject.CompareTag("Player")) {
			// アイテム数を減らす
			iCount--;
			// アイテム数が0以下になったら全部取ったのでクリアー
			if (iCount <= 0) {
				SceneManager.LoadScene ("Clear");
			}

			// プレイヤーなので、自分を削除
			Destroy(gameObject);
		}
	}
}
