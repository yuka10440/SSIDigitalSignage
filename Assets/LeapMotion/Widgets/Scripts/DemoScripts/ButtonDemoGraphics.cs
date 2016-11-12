using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ButtonDemoGraphics : MonoBehaviour 
{
	public void SetActive(bool status)
	{
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		Text[] texts = GetComponentsInChildren<Text>();

		RawImage[] GUIimages = GetComponentsInChildren<RawImage>();
		foreach(RawImage image in GUIimages){
			image.enabled = status;
		}
		foreach (Renderer renderer in renderers)
		{
			renderer.enabled = status;
		}
		foreach(Text text in texts){
			text.enabled = status;
		}

		
	}
	
	public void SetColor(Color color)
	{
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		Text[] texts = GetComponentsInChildren<Text>();
		RawImage[] GUIimages = GetComponentsInChildren<RawImage>();
		foreach (Renderer renderer in renderers)
		{
			renderer.material.color = color;
		}
		foreach (Text text in texts){
			text.color = color;
		}
		foreach(RawImage image in GUIimages){
			image.color = color;
		}
	}
}
