
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	// UI Ekranında gösterilecek olan şeyler bu script dosyasında tutulacak

	private void Awake()
	{
		instance = this;
	}
}
