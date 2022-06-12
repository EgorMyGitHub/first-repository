using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
	[field: SerializeField]
	private float damping = 1.5f;

	[field: SerializeField]
	private Vector3 offset = new Vector3(2f, 1f,3f);
	
	[field: SerializeField]
	private Player Player;

	private Transform player;
	
	private int lastX;

	private void Awake()
	{
		offset = new Vector3(Mathf.Abs(offset.x), offset.y,offset.z);
		FindPlayer();
	}

	private void FindPlayer()
	{
		player = Player.transform;
		lastX = Mathf.RoundToInt(player.position.x);
		
		transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
	}

	private void Update()
	{
		if (player)
		{
			lastX = Mathf.RoundToInt(player.position.x);

			Vector3 target;
			
			target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
			
			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}
