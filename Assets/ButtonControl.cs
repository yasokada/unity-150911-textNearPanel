using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {
	public Canvas myCanvas;
	public GameObject myPanel;
	
	void drawTextOnTheLeftOfPanel(float val, bool atBottom) {
		RectTransform panelRect = myPanel.GetComponent<RectTransform> ();
		float width = panelRect.rect.width;
		float height = panelRect.rect.height;
		
		RectTransform canvasRect = myCanvas.GetComponent<RectTransform> ();
		
		// Bottom Left
		Vector3 pos;
		pos = myPanel.transform.position;
		pos.x -= width * 0.5f * canvasRect.localScale.x;
		if (atBottom) {
			pos.y -= height * 0.5f * canvasRect.localScale.y;
		} else {
			pos.y += height * 0.5f * canvasRect.localScale.y;
		}
		
		GameObject BottomLeftGO = new GameObject ();
		BottomLeftGO.transform.parent = myPanel.transform;
		BottomLeftGO.name = "Text";
		BottomLeftGO.transform.position = pos;
		BottomLeftGO.transform.localScale = new Vector3 (1f, 1f, 1f);
		Text BottomLeftText = BottomLeftGO.AddComponent<Text> ();
		BottomLeftText.text = val.ToString ();
		BottomLeftText.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
	}
	
	public void ButtonClick() {
		Debug.Log ("button click");
		drawTextOnTheLeftOfPanel (3.1415f, /* atBottom=*/ true);
		drawTextOnTheLeftOfPanel (2.7182f, /* atBottom=*/ false);
	}
}
