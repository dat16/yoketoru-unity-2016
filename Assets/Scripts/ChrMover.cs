using UnityEngine;
using System.Collections;

public class ChrMover : MonoBehaviour {
	/** 最低速度(秒速)*/
	public float min = 1f;
	/** 最高速度*/
	public float max = 4f;
	/** 実際の速度*/
	private float speed;
	/** 速度の設定用のRigidbodyのインスタンス*/
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		// 自分についているRigidbodyのインスタンスを得る
		rb = GetComponent<Rigidbody> ();

		// 角度を0～360で乱数を求める(Random.valueが0～1未満の乱数)
		float dir = Random.value*360f;

		// 速度を、最低速度(min)から最大速度(max)までの間で求める
		speed = Random.Range(min, max);

		// 上記を使って最初の速度ベクトルを求める
		//// Quaternion(クォータニオン)=角度(回転)を制御する。
		//// Angle=角度 / Axis=軸 = 指定したベクトルを中心軸にして、指定の角度回転する要素を求める
		//// 今回は、Vector3.forward=前方の意味。z方向プラスを中心軸にするということ
		//// (奥行き=Z=forward / 上=Y=up / 右=X=right)
		Vector3 vel = Quaternion.AngleAxis(dir, Vector3.forward) * Vector3.up * speed;

		// 求めた速度ベクトルを、初速に設定する
		rb.velocity = vel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// normalized=長さ1のベクトルを返す
		// これにより、dirに、速度1の現在の速度ベクトルが求まる
		Vector3 dir = rb.velocity.normalized;

		// 停止を強制的に解除
		//// magnitude=長さを返す
		//// float.Epsilon(イプシロン)はfloatであらわせる最短。
		//// これ以下なら0とみなせる)
		if (dir.magnitude <= float.Epsilon) {
			dir = Quaternion.AngleAxis (
				Random.value * 360f,
				Vector3.forward) * Vector3.up;
		}

		// 長さ1のベクトルにspeedをかければ、speedの速度が得られる
		rb.velocity = dir * speed;
	}
}
