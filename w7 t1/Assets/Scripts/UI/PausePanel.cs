using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PausePanel : MonoBehaviour
{
	Canvas canvas;
	public TextMeshProUGUI score;
	//public Button continues;
	public void Pause()
	{
		Time.timeScale = 0;
		canvas.enabled = true;
		score.enabled = false;

	}
    private void Awake()
    {
		//continues = GetComponentInChildren<Button>();
		canvas = GetComponentInChildren<Canvas>();
		canvas.enabled = false;
	}
	public void Continues()
    {
		Time.timeScale = 1;
		canvas.enabled = false;
		score.enabled = true;
	}
}
