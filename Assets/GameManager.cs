using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public bool isGameOn;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		OnGameStart();
	}

	public void OnGameStart()
	{
		isGameOn = true;
	}
}
