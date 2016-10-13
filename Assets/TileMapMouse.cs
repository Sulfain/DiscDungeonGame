using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	public Transform selectionCube;
	
	public TileMap tileMap;
	Vector3 currentTileCoord;
	public Collider coll;
	// Use this for initialization
	void Start () 
	{
	tileMap = GetComponent<TileMap>();	
		coll = GetComponent<Collider>();
	}
	// Update is called once per frame
	void Update () 
	{
		
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition);
		RaycastHit hitInfo;
		if(coll.Raycast( ray, out hitInfo, Mathf.Infinity))
		{
			int x = Mathf.FloorToInt( hitInfo.point.x / tileMap.tileSize);
			int z = Mathf.FloorToInt( hitInfo.point.z / tileMap.tileSize);
			Debug.Log("Tile: "+ x + ", " + z);

			currentTileCoord.x = x;
			currentTileCoord.z = z;

			selectionCube.transform.position = currentTileCoord*5f;
		}
		else
		{
		//something maybe hide the code
		}

	
	}
}
