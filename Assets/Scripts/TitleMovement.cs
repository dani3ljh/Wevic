using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour
{
	[SerializeField] private float distance;

	private float startingY;
	private float maxY;
	private float minY;
	private bool isMovingUp = true;
	
	private RectTransform rt;
	
    private void Start()
    {
		rt = gameObject.GetComponent<RectTransform>();
		
		startingY = rt.anchoredPosition.y;
		maxY = startingY + distance;
		minY = startingY - distance;
    }
	
	private void Update()
	{
		Vector2 pos = rt.anchoredPosition;
		
		if(isMovingUp){
			// Debug.Log("Moving up");
			if(pos.y >= maxY){
				isMovingUp = false;
				return;
			}
			
			rt.anchoredPosition = new Vector2(pos.x, pos.y + (Time.deltaTime * 100));
			
		}
		if(!isMovingUp){
			// Debug.Log("Moving down");
			if(pos.y <= minY){
				isMovingUp = true;
				return;
			}
			
			rt.anchoredPosition = new Vector2(pos.x, pos.y - (Time.deltaTime * 100));
			
		}
	}
}
