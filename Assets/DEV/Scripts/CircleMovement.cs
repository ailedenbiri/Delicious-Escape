using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class CircleMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject mouseGO;
    [SerializeField] float rotationSpeed = 50f;

    private float rotationIncreaseRate = 5f;
    private float timer = 0f;
    private Rigidbody2D rb;


    [Header("Shake Settings")]
    [SerializeField] GameObject circleGO;
    [SerializeField] float duration;
    [SerializeField] float strenght;
    [SerializeField] int vibrato;
    [SerializeField] float randomness;


    void Start()
    {
        StartCoroutine(ShakeCircle());
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            rotationSpeed += rotationIncreaseRate;
            timer = 0f;
        }

        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);

       
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (DOTween.IsTweening(mouseGO.transform))
            {
                return;
            }

            if(mouseGO.transform.localPosition.x <= -5f)
            {
                mouseGO.transform.DOLocalMoveX(6.65f, 0.3f);
            }
            else
            {
                mouseGO.transform.DOLocalMoveX(-6.65f, 0.3f);
            }               

        }
    }


    
    IEnumerator ShakeCircle()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            circleGO.transform.DOShakePosition(duration, strenght, vibrato, randomness);
        }
    }
    

}



