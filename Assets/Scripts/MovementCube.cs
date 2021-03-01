using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
	public Rigidbody rb;
	public float forwardSpeed;
	public List<GameObject> stackCubes;
	[Space(50)]
	public GameObject childPrefab;

	private void FixedUpdate()
	{
		rb.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			Debug.Log("Çalıştı");
			stackCubes.Remove(gameObject);
			transform.SetParent(null);
		}
		if (collision.gameObject.CompareTag("BonusCube"))
		{
			AddBonusCube(collision);

		}
	}


	public void AddBonusCube(Collision collision)
	{
		Destroy(collision.gameObject); // ÇARPTIĞIMIZ BONUS SİLİNDİ
		var go = Instantiate(childPrefab); // YENİ BİR GAMEOBJECT ÜRETİLDİ
		go.transform.position = stackCubes[stackCubes.Count -1].transform.position; // DİZİNİN O ANKİ EN ALTTAKİ ELAMANIN YERİNE YENİ OLUŞAN GO GETİRİLDİ
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.position.y + go.transform.localScale.y, transform.position.z); // ONCEKİ DİZİ ELEMANLARI TOPLU ŞEKİLDE YUKARI ÇIKARILDI.
		go.transform.SetParent(gameObject.transform); // YENİ EKLENEN OBJENİN HAREKETİ SAĞLAMASI İÇİN CHİLD YAPILDI
		stackCubes.Add(go); // BİR SONRAKİ YER AYARLAMA İŞLEMİNİN DÜZGÜN OLMASI İÇİN DİZİYE EKLENDİ.
		
	}


}
