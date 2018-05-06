using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombExplosion : MonoBehaviour {

	public ParticleSystem explosionParticles;
	public GameObject graphics;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void OnCollisionEnter2D (Collision2D coll) {
	
		Destroy(gameObject, 2);
		rigid.simulated = false;
		graphics.SetActive(false);

		GameObject explodoWalls = GameObject.FindWithTag("ExplodoWalls");
		Tilemap wallsExplodo = explodoWalls.GetComponent<Tilemap>();
		Vector3Int gridPosBomb = wallsExplodo.WorldToCell(transform.position);
		
		for (int x = gridPosBomb.x-5 ; x<=gridPosBomb.x+5 ; x++) {
			for (int y = gridPosBomb.y-5 ; y<=gridPosBomb.y+5 ; y++) {
				Vector3Int explodingTile = new Vector3Int (x,y,gridPosBomb.z);
				Vector3 worldTilePos = wallsExplodo.CellToWorld(explodingTile);
				float distance = Vector2.Distance(transform.position, worldTilePos);
				if (distance < 10) {
					wallsExplodo.SetTile(explodingTile, null);
				}
			}
		}
		explosionParticles.Play();
	}
}
