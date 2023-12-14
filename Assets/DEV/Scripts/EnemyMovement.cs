using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float rotationDuration;
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] GameObject catGO;


    [Header("Shake Settings")]
    [SerializeField] GameObject circleGO;
    [SerializeField] float duration;
    [SerializeField] float strenght;
    [SerializeField] int vibrato;
    [SerializeField] float randomness;

    private float rotationIncreaseRate =15f;
    private float timer = 0f;
    private Rigidbody2D rb;
    private float elapsedTime = 0.0f;
    private bool isFirstRotationDone = false;

    private void Start()
    {
        StartCoroutine(MoveYPosition());
        StartCoroutine(ShakeCircle());
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {       
            rotationSpeed += rotationIncreaseRate;
            timer = 0f;
        }
        if (!isFirstRotationDone)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
           
           if (elapsedTime >= rotationDuration)
           {
                isFirstRotationDone = true;
           }
        }
        else
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

    }
        
  
    IEnumerator MoveYPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f);
            catGO.transform.DOLocalMoveY(-7.85f, 2f).OnComplete(() =>
            {
                catGO.transform.DOLocalMoveY(7.85f, 2f);
            });
        }
    } 
 
    IEnumerator ShakeCircle()
    {
        while(true)
        {
            yield return new WaitForSeconds(30f);
            circleGO.transform.DOShakePosition(duration, strenght, vibrato, randomness);
        }
    } 
  

}



