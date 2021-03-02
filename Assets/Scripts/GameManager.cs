using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[Header("GAME CONTROL BOOL")]
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
