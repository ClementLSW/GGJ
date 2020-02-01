using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERLASER;
using NaughtyAttributes;
using System;
using System.Linq;
using UnityEngine.Events;

public class GridController : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    private List<GridTile> gridTiles;

    [Header("Grid Limits")]
    [SerializeField] private int minHeight;
    [SerializeField] private int maxHeight;
    [SerializeField] private int minWidth;
    [SerializeField] private int maxWidth;
    [SerializeField] private Vector2 startPosition = new Vector2(1, 1);

    [Header("Prefabs")]
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private GameObject metalPrefab;
    [SerializeField] private GameObject turretPrefab;

    private enum MoveDirection { UP, DOWN, LEFT, RIGHT };

    private Vector2 selectedTile;

    private void Start()
    {
        selectedTile = startPosition;
        SetAllTiles();

        if (playerNumber == 1)
        {
            InputManager.instance.On_P1_DPAD_UP_Click.AddListener(delegate { MoveCursor(MoveDirection.UP); });
            InputManager.instance.On_P1_DPAD_DOWN_Click.AddListener(delegate { MoveCursor(MoveDirection.DOWN); });
            InputManager.instance.On_P1_DPAD_LEFT_Click.AddListener(delegate { MoveCursor(MoveDirection.LEFT); });
            InputManager.instance.On_P1_DPAD_RIGHT_Click.AddListener(delegate { MoveCursor(MoveDirection.RIGHT); });
        }
        if (playerNumber == 2)
        {
            InputManager.instance.On_P2_DPAD_UP_Click.AddListener(delegate { MoveCursor(MoveDirection.UP); });
            InputManager.instance.On_P2_DPAD_DOWN_Click.AddListener(delegate { MoveCursor(MoveDirection.DOWN); });
            InputManager.instance.On_P2_DPAD_LEFT_Click.AddListener(delegate { MoveCursor(MoveDirection.LEFT); });
            InputManager.instance.On_P2_DPAD_RIGHT_Click.AddListener(delegate { MoveCursor(MoveDirection.RIGHT); });
        }
    }

    private void SetAllTiles()
    {
        gridTiles = GetComponentsInChildren<GridTile>().ToList();
        foreach (GridTile gridTile in gridTiles)
        {
            gridTile.SetTileMode(GridTile.TileMode.UNSELECTED);
        }
        gridTiles.Find(x => x.TileIndex == startPosition).SetTileMode(GridTile.TileMode.SELECTED);
    }

    private void MoveCursor(MoveDirection dir)
    {
        if (dir == MoveDirection.DOWN)
        {
            if (selectedTile.y == minHeight)
                return;

            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.UNSELECTED);
            selectedTile += new Vector2(0, -1);
            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.SELECTED);
        }

        if (dir == MoveDirection.UP)
        {
            if (selectedTile.y == maxHeight)
                return;

            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.UNSELECTED);
            selectedTile += new Vector2(0, 1);
            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.SELECTED);
        }

        if (dir == MoveDirection.LEFT)
        {
            if (selectedTile.x == minWidth)
                return;

            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.UNSELECTED);
            selectedTile += new Vector2(-1, 0);
            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.SELECTED);
        }
            
        if (dir == MoveDirection.RIGHT)
        {
            if (selectedTile.x == maxWidth)
                return;

            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.UNSELECTED);
            selectedTile += new Vector2(1, 0);
            gridTiles.Find(x => x.TileIndex == selectedTile).SetTileMode(GridTile.TileMode.SELECTED);
        }
    }

    public void Build(ComboKeysIdentifier.ComboType comboType)
    {
        GameObject targetPrefab = null;
        switch (comboType)
        {
            case ComboKeysIdentifier.ComboType.BUILD_WOOD:
                targetPrefab = woodPrefab;
                break;
            case ComboKeysIdentifier.ComboType.BUILD_METAL:
                targetPrefab = metalPrefab;
                break;
            case ComboKeysIdentifier.ComboType.BUILD_TURRET:
                targetPrefab = turretPrefab;
                break;
        }

        GridTile targetTile = gridTiles.Find(x => x.TileIndex == selectedTile);
        GameObject newBuilding = Instantiate(targetPrefab, targetTile.transform.position, Quaternion.identity);
        targetTile.building = newBuilding;
    }

    public List<GridTile> GetNeighbourTiles(Vector2 tileIndex)
    {
        List<GridTile> tiles = new List<GridTile>();

        Vector2 left = tileIndex + new Vector2(-1, 0);
        Vector2 right = tileIndex + new Vector2(1, 0);
        Vector2 up = tileIndex + new Vector2(0, 1);
        Vector2 down = tileIndex + new Vector2(0, -1);

        if (left.x != minWidth)
            gridTiles.Add(gridTiles.Find(x => x.TileIndex == left));

        if (right.x == maxWidth)
            gridTiles.Add(gridTiles.Find(x => x.TileIndex == right));

        if (up.x == maxHeight)
            gridTiles.Add(gridTiles.Find(x => x.TileIndex == up));

        if (down.x == minHeight)
            gridTiles.Add(gridTiles.Find(x => x.TileIndex == down));

        return gridTiles;
    }

    public void DestroySelectedBuilding()
    {
        GridTile targetTile = gridTiles.Find(x => x.TileIndex == selectedTile);
        targetTile.building.GetComponent<Block>().DestroyBlock();
    }
}
