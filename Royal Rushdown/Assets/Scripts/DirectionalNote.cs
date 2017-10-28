using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalNote : MonoBehaviour {

    // Use this for initialization
    public enum Direction
    {
        Up, Right, Down, Left
    }
    public Direction direction = Direction.Right;
    public float heightOffset = 0;
    void Start () {
        transform.position = Vector3.zero;

    }

    // Update is called once per frame
    void Update () {
	}
    public void followEnemy(Transform enemyTransform, float offset)
    {
        transform.SetParent(enemyTransform);
        transform.position = Vector3.zero;
        heightOffset = offset;
        transform.position = Vector3.up * heightOffset;
    }
    public void updateOffset(float newOffset)
    {
        transform.position = Vector3.zero;
        heightOffset = newOffset;
        transform.position = Vector3.up * heightOffset;


    }
    public int getDirection()
    {
        return (int)direction;
    }
    public void setDirection(Direction dir)
    {
        direction = dir;
        switch (dir)
        {
            case (Direction.Right):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case (Direction.Down):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case (Direction.Left):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case (Direction.Up):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
        }
    }
    public void setDirection(int dir)
    {
        direction = (Direction)dir;
        switch (dir)
        {
            case (1):
                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                break;
            case (2):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case (3):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case (0):
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
        }
    }
}
