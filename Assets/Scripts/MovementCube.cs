using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementCube : MonoBehaviour
{
	[Header("Components && Variables")]
	public GameObject childPrefab;
	public Transform trailerRendererObject;
	[SerializeField] Rigidbody rb;
	public float forwardSpeed;

	[Header("Child Array")]
	public List<GameObject> stackCubes;

	private void Update()
	{
		transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("BonusCube"))
		{
			AddBonusCube(other);
		}
	}
	public void AddBonusCube(Collider collision)
	{
		Destroy(collision.gameObject); // ÇARPTIĞIMIZ BONUS SİLİNDİ
		var go = Instantiate(childPrefab); // YENİ BİR GAMEOBJECT ÜRETİLDİ
		go.transform.position = stackCubes[stackCubes.Count -1].transform.position; // DİZİNİN O ANKİ EN ALTTAKİ ELAMANIN YERİNE YENİ OLUŞAN GO GETİRİLDİ
		
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.position.y + go.transform.localScale.y, transform.position.z); // ONCEKİ DİZİ ELEMANLARI TOPLU ŞEKİLDE YUKARI ÇIKARILDI.
		go.transform.SetParent(gameObject.transform); // YENİ EKLENEN OBJENİN HAREKETİ SAĞLAMASI İÇİN CHİLD YAPILDI
		stackCubes.Add(go); // BİR SONRAKİ YER AYARLAMA İŞLEMİNİN DÜZGÜN OLMASI İÇİN DİZİYE EKLENDİ.

		float cloneCubeScale = go.transform.localScale.y;
		trailerRendererObject.position = new Vector3(gameObject.transform.position.x, trailerRendererObject.transform.position.y - cloneCubeScale, transform.position.z); ; // TRAİLER RENDERERIN POZİSYONU SABİT TUTULDU.
	}

}
