using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[Header("GAME CONTROL BOOL")]
	public bool isGameOn;
	public bool rotateClamp = false;
	public bool isRotate = false;

	private void Awake()
	{
		instance = this;
	}

	public void OnGameStart()
	{
		isGameOn = true;
		UIManager.instance.StartedScreenUI();
	}
	public void OnGameFinish()
	{
		isGameOn = false;
		UIManager.instance.FinishScreenUI();
	}
}
