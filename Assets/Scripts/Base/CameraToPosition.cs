using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPosition : MonoBehaviour
{
    private Camera cam;
    private Vector2 horPos; // contain camera horizontal position 
    private Vector2 verPos; // contain camera vertical position
    [SerializeField] private float paddingX; // contain X - aixs edge padding
    [SerializeField] private float paddingY; // contain Y - aixs edge padding 
    [SerializeField] private float resetPadding;
    [SerializeField] public Vector3 randomPos;

    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private float middleY;
    private float middleX;

    public static CameraToPosition instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
       

    }
    public Vector3 GetRandomPosition() => RanndomMovePosition();
    public Vector3 GetRandomHalfPosition(float paddingX, float paddingY) => RanndomMoveHalfPosition(paddingX, paddingY);

    public Vector3 ResetPlayerPosition()
    {
        Vector3 position = Vector3.zero;
        position.x = middleX;
        position.y = minY + resetPadding; ;

        return position;
    }
    private Vector3 RanndomMovePosition()
    {

        Vector3 position = Vector3.zero;

        position.x = Random.Range(minX + paddingX, maxX - paddingX);
        position.y = Random.Range(minY + paddingY, maxY - paddingY);
        randomPos = position;

        return position;

    }
    private Vector3 RanndomMoveHalfPosition(float paddingX,float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = Random.Range(minX + paddingX, maxX - paddingX);
        position.y = Random.Range(middleY, maxY - paddingY);


        randomPos = position;

        return position;
    }
    public Vector3 RandomSpawnPostion(float paddingX, float paddingY)
    {
        Vector3 postion = Vector3.zero;
        postion.x = Random.Range(minX + paddingX, maxX - paddingX);
        postion.y = maxY+paddingY; 


        return postion;
    }
    public Vector3 PlayerMovePositon(Vector3 playerPosition)
    {
        Vector3 position = Vector3.zero;
        position.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        position.y = Mathf.Clamp(playerPosition.y, minY, maxY);
        return position;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector2 botLeft = cam.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector2 botRight = cam.ViewportToWorldPoint(new Vector3(1f, 1f));
        middleX = cam.ViewportToWorldPoint(new Vector3(0.5f,0f,0f)).x;
        middleY = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).y;
        
        minX = botLeft.x;
        minY = botLeft.y;
        maxX = botRight.x;
        maxY = botRight.y;

       
    }



}
