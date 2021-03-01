using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
	[Header("Components && Variables")]
	public GameObject childPrefab;
	[SerializeField] Rigidbody rb;
	public float forwardSpeed;

	[Header("Child Array")]
	public List<GameObject> stackCubes;
	

	private void FixedUpdate()
	{
		//rb.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
		rb.AddForce(Vector3.forward * 50 * Time.deltaTime, ForceMode.Impulse);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("BonusCube"))
		{
			AddBonusCube(collision);
		}else if (collision.gameObject.CompareTag("Obstacle"))
		{
			GroundHit(collision);
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


	public void GroundHit(Collision collision)
	{
		Collider myCollider = collision.contacts[0].thisCollider;
		myCollider.transform.SetParent(null);
		stackCubes.Remove(myCollider.gameObject);
	}
}
