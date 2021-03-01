
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	// UI Ekranında gösterilecek olan şeyler bu script dosyasında tutulacak. Gerekli fonksiyonlar oluştulup ilgili yerlerde çağrılacak.
	private void Awake()
	{
		instance = this;
	}
}
