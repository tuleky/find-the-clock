using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeByTime : MonoBehaviour
{
	private Outline outline;
	float lerpAmount = 0f;
    Color rndColor;

	void Start()
	{
        outline = GetComponent<Outline>();
        rndColor = Random.ColorHSV();
    }

    void Update()
	{
		ChangeColor();
	}

	void ChangeColor()
	{
		lerpAmount += Time.deltaTime / 5f;
        //outline.effectColor = Color.Lerp(Color.gray, Color.cyan, lerpAmount);
        outline.effectColor = Color.Lerp(outline.effectColor, rndColor, lerpAmount);
        if (outline.effectColor == rndColor)
        {
            rndColor = Random.ColorHSV();
            lerpAmount = 0f;
        }
    }
}
