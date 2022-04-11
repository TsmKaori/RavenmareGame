using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Transform heroTransform;

    [SerializeField] private Tilemap groundTileMap;
    [SerializeField] private Tilemap collisionTilemap;

    [SerializeField] private Tile groundTile;
    [SerializeField] private Tile wallDownTile;
    [SerializeField] private Tile wallUpTile;

    private int previousX = 0;
    private int previousY = 0;

    private TileBase[] groundTileColumn = new TileBase[10];
    private TileBase[] collisionTileColumn = new TileBase[2];

    void Awake()
    {
        collisionTileColumn[0] = wallDownTile;
        groundTileColumn[0] = groundTile;
        groundTileColumn[1] = groundTile;
        groundTileColumn[2] = groundTile;
        groundTileColumn[3] = groundTile;
        groundTileColumn[4] = groundTile;
        groundTileColumn[5] = groundTile;
        groundTileColumn[6] = groundTile;
        groundTileColumn[7] = groundTile;
        groundTileColumn[8] = groundTile;
        groundTileColumn[9] = groundTile;
        collisionTileColumn[1] = wallUpTile;
    }

    void FixedUpdate()
    {
        int standingX = (int)Mathf.Floor(heroTransform.position.x);
        int standingY = (int)Mathf.Floor(heroTransform.position.y);

        if (standingX != previousX) // if we're in a new column
        {
            int right = 1;
            if (standingX < previousX) right = -1;

            // determine the coordinates of each tile in the new column
            Vector3Int[] revealedGroundTiles = new Vector3Int[10];
            Vector3Int[] revealedCollisionTiles = new Vector3Int[2];

            for (int i = 0; i < 10; i++)
            {
                revealedGroundTiles[9 - i] = new Vector3Int(standingX + (8 * right), i - 5);
            }

            revealedCollisionTiles[0] = new Vector3Int(standingX + (8 * right), 5);
            revealedCollisionTiles[1] = new Vector3Int(standingX + (8 * right), -6);

            groundTileMap.SetTiles(revealedGroundTiles, groundTileColumn);
            collisionTilemap.SetTiles(revealedCollisionTiles, collisionTileColumn);
        }

        previousX = standingX;
        previousY = standingY;




    }
}
