using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Transform heroTransform;

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap detailTilemap;
    [SerializeField] private Tilemap collisionTilemap;

    [SerializeField] private Tile groundTile;
    [SerializeField] private Tile rockTile;
    [SerializeField] private Tile bloodTile;
    [SerializeField] private Tile bloodTileSm;
    [SerializeField] private Tile pentaTile;
    [SerializeField] private Tile candlesTile;
    [SerializeField] private Tile holeTile;
    [SerializeField] private Tile wallDownTile;
    [SerializeField] private Tile wallUpTile;
    [SerializeField] private Tile wallUpTile2;

    [SerializeField] private Tile bigBrick;
    [SerializeField] private Tile bigBrick2;
    [SerializeField] private Tile bloods;
    [SerializeField] private Tile bloods2;
    [SerializeField] private Tile boneses;
    [SerializeField] private Tile boneses2;
    [SerializeField] private Tile cracks;
    [SerializeField] private Tile cracks2;
    [SerializeField] private Tile rock2;
    [SerializeField] private Tile rocksm3;
    [SerializeField] private Tile rocksm4;
    [SerializeField] private Tile rocksm5;
    [SerializeField] private Tile skull;
    [SerializeField] private Tile skull2;

    Tile[] detailsArray = new Tile[13];
    Tile[] detailsArrayC = new Tile[7];




    [SerializeField] private float detailRate = 0.4f;
    [SerializeField] private float doubleDetailRate = 0.2f;

    private int previousX = 0;
    private int maxX = 0;
    private int minX = 0;
    private int previousY = 0;

    private TileBase[] groundTileColumn = new TileBase[12];
    private TileBase[] collisionTileColumn = new TileBase[2];

    void Awake()
    {
        detailsArray[0] = bloodTile;
        detailsArray[1] = bloodTileSm;
        detailsArray[2] = candlesTile;
        detailsArray[3] = pentaTile;
        detailsArray[4] = bloods;
        detailsArray[5] = bloods2;
        detailsArray[6] = boneses;
        detailsArray[7] = boneses2;
        detailsArray[8] = cracks;
        detailsArray[9] = cracks2;
        detailsArray[10] = rocksm3;
        detailsArray[11] = rocksm4;
        detailsArray[12] = rocksm5;


        detailsArrayC[0] = rockTile;
        detailsArrayC[1] = holeTile;
        detailsArrayC[2] = bigBrick;
        detailsArrayC[3] = bigBrick2;
        detailsArrayC[4] = rock2;
        detailsArrayC[5] = skull;
        detailsArrayC[6] = skull2;

        collisionTileColumn[0] = wallUpTile;
        groundTileColumn[0] = wallUpTile2;
        groundTileColumn[1] = groundTile;
        groundTileColumn[2] = groundTile;
        groundTileColumn[3] = groundTile;
        groundTileColumn[4] = groundTile;
        groundTileColumn[5] = groundTile;
        groundTileColumn[6] = groundTile;
        groundTileColumn[7] = groundTile;
        groundTileColumn[8] = groundTile;
        groundTileColumn[9] = groundTile;
        groundTileColumn[10] = groundTile;
        groundTileColumn[11] = groundTile;
        collisionTileColumn[1] = wallDownTile;
    }

    void FixedUpdate()
    {
        int standingX = (int)Mathf.Floor(heroTransform.position.x);
        int standingY = (int)Mathf.Floor(heroTransform.position.y);

        if (standingX != previousX) // if we're in a new column
        {

            // check if we're revealing a new column
            if (standingX > maxX || standingX < minX)
            {
                //  update the max/min x
                if (standingX > maxX)
                {
                    maxX = standingX;
                }
                else if (standingX < minX)
                {
                    minX = standingX;
                }

                // check if we're going right
                int right = 1;
                if (standingX < previousX) right = -1;

                // determine the coordinates of each tile in the new column
                Vector3Int[] revealedGroundTiles = new Vector3Int[13];
                Vector3Int[] revealedCollisionTiles = new Vector3Int[2];

                for (int i = 0; i < 12; i++)
                {
                    revealedGroundTiles[11 - i] = new Vector3Int(standingX + (8 * right), i - 5);
                }

                revealedCollisionTiles[0] = new Vector3Int(standingX + (8 * right), 5);
                revealedCollisionTiles[1] = new Vector3Int(standingX + (8 * right), -6);

                groundTilemap.SetTiles(revealedGroundTiles, groundTileColumn);
                collisionTilemap.SetTiles(revealedCollisionTiles, collisionTileColumn);



                // spawn random details
                float seed = Random.Range(0f, 1f);

                if (Mathf.Abs(seed - Random.Range(0f, 1f)) < detailRate)
                {


                    int Y = Random.Range(-5, 5);

                    if (seed > .75f)
                    {
                        Tile detail = detailsArrayC[Random.Range(0, detailsArrayC.Length)];
                        SpawnDetail(Y, standingX, right, collisionTilemap, detail);
                    }
                    else
                    {
                        Tile detail = detailsArray[Random.Range(0, detailsArray.Length)];
                        SpawnDetail(Y, standingX, right, detailTilemap, detail);
                    }

                    // this is a really dumb way to do this 
                    if (Mathf.Abs(seed - Random.Range(0f, 1f)) < doubleDetailRate)
                    {
                        int Y2 = Random.Range(-5, 5);
                        if (Y2 != Y)
                        {
                            Tile detail = detailsArray[Random.Range(0, detailsArray.Length)];
                            SpawnDetail(Y2, standingX, right, detailTilemap, detail);
                        }
                    }

                }
            }

        }

        previousX = standingX;
        previousY = standingY;
    }

    void SpawnDetail(int Y, int standingX, int right, Tilemap tilemap, Tile tile)
    {
        tilemap.SetTile(new Vector3Int(standingX + (8 * right), Y), tile);
    }
}
