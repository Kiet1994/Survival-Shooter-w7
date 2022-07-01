using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
	public Slider Musis;
	public Slider EffectSound;
	const string musis = "Musis";
	const string effectSound = "EffectSound";
	public AudioMixer SoundManager;

	public void Start()
	{
		Musis.value = PlayerPrefs.GetFloat(musis);
		EffectSound.value = PlayerPrefs.GetFloat(effectSound);
	}
	
	public void SetEffect(float SoundEffect)// truyền giá trị vào Effect.
	{
		SoundManager.SetFloat("Effect", SoundEffect);
	}

	public void SetMusic(float Music)
	{
		SoundManager.SetFloat("Music", Music);
	}
	public void SaveMusic()
	{
		PlayerPrefs.SetFloat(musis, Musis.value);
	}
	public void SaveEffectSound()
	{
		PlayerPrefs.SetFloat(effectSound, EffectSound.value);
	}
	
}
