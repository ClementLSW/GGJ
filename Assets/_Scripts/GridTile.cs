using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class GridTile : MonoBehaviour
{
    public Vector2 TileIndex
    {
        get
        {
            string[] values = gameObject.name.Split(',');
            return new Vector2(int.Parse(values[0]), int.Parse(values[1]));
        }
    }
    private SpriteRenderer tileImg;

    public enum TileMode { UNSELECTED, SELECTED };

    private void OnEnable()
    {
        tileImg = GetComponent<SpriteRenderer>();
    }

    public GameObject building;

    public void SetTileMode(TileMode tileMode)
    {
        switch (tileMode)
        {
            case TileMode.UNSELECTED:
                tileImg.color = new Color(1, 1, 1, 0);
                break;
            case TileMode.SELECTED:
                tileImg.color = new Color(1, 1, 1, 1);
                break;
            default:
                break;
        }
    }

    [Button]
    public void SetTileMode_UNSELECTED()
    {
        SetTileMode(TileMode.UNSELECTED);
    }

    [Button]
    public void SetTileMode_SELECTED()
    {
        SetTileMode(TileMode.SELECTED);
    }
}
