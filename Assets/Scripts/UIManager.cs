using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	// UI Ekranında gösterilecek olan şeyler bu script dosyasında tutulacak. Gerekli fonksiyonlar oluştulup ilgili yerlerde çağrılacak.
	private void Awake()
	{
		instance = this;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
