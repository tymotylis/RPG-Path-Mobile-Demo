using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScroll : MonoBehaviour
{
	public int chunkSize;
	public int renderDistance;
	public Tilemap tilemap;
	public Tile fillTile;

	private int needle;

	private void Awake()
	{
		needle = 0;
	}

	public void OnPlayerMove(GridVector where)
	{
		if (where.Y + renderDistance >= needle)
			UpdateChunk(where);

	}

	private void UpdateChunk(GridVector where)
	{
		for (int i = 0; i < chunkSize; i++)
		{
			DrawLine(needle + i);
		}

		needle += chunkSize;

		if (where.Y + renderDistance >= needle)
			UpdateChunk(where);
	}

	private void DrawLine(int y)
	{
		for (int i = -3; i <= 1; i++)
		{
			tilemap.SetTile(new Vector3Int(i, y, 0), fillTile);
		}
	}
}
