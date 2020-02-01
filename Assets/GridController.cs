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

    [Space(10)]
    [SerializeField] private Vector2 startPosition = new Vector2(1, 1);

    private enum MoveDirection { UP, DOWN, LEFT, RIGHT };

    private Vector2 selectedTile;

    private void Start()
    {
        selectedTile = startPosition;
        SetAllTiles();

        if (playerNumber == 2)
        {
            InputManager.instance.On_P2_DPAD_UP_Click.AddListener(delegate { MoveCursor(MoveDirection.UP); });
            InputManager.instance.On_P2_DPAD_DOWN_Click.AddListener(delegate { MoveCursor(MoveDirection.DOWN); });
            InputManager.instance.On_P2_DPAD_LEFT_Click.AddListener(delegate { MoveCursor(MoveDirection.LEFT); });
            InputManager.instance.On_P2_DPAD_RIGHT_Click.AddListener(delegate { MoveCursor(MoveDirection.RIGHT); });
        }
        if (playerNumber == 3)
        {
            InputManager.instance.On_P3_DPAD_UP_Click.AddListener(delegate { MoveCursor(MoveDirection.UP); });
            InputManager.instance.On_P3_DPAD_DOWN_Click.AddListener(delegate { MoveCursor(MoveDirection.DOWN); });
            InputManager.instance.On_P3_DPAD_LEFT_Click.AddListener(delegate { MoveCursor(MoveDirection.LEFT); });
            InputManager.instance.On_P3_DPAD_RIGHT_Click.AddListener(delegate { MoveCursor(MoveDirection.RIGHT); });
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
}
