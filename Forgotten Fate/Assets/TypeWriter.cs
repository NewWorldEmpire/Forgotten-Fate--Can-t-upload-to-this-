using UnityEngine;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
	private const float WAIT_TIME = 0.05f;
	
	private float waitTimer = 0.0f;
	private string wholeText = "This is a simple text. Is this fast enough for you Sam?";
	private string typewriterText = "";
	private int currentIndex = 0;
	
	void Update ()
	{
		waitTimer += Time.deltaTime;
		
		if (waitTimer > WAIT_TIME && currentIndex < wholeText.Length)
		{            
			typewriterText += wholeText[currentIndex];
			waitTimer = 0.0f;
			++currentIndex;
		}      
	}
	
	void OnGUI()
	{
		GUI.TextArea(new Rect(0.0f, 0.0f, 300.0f, 100.0f), typewriterText);
	}
}