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
    public float desiredOffset;
    public float moveDownSpeed;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(transform.localPosition.y - desiredOffset > moveDownSpeed*Time.deltaTime)
        {
            transform.localPosition= transform.localPosition + Vector3.down * moveDownSpeed * Time.deltaTime;
        } else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, desiredOffset, 0);
        }
	}
    public void followEnemy(Transform enemyTransform, float offset)
    {
        transform.SetParent(enemyTransform);
        transform.localPosition = Vector3.up * offset;
        desiredOffset = offset;
    }
    public void updateOffset(float newOffset)
    {
        desiredOffset = newOffset;
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
