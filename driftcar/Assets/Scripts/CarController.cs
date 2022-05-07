using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    float carSpeed;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float steerAngle; //a��yla d�nme i�lemi i�in.

    [SerializeField]
    float Traction; // �eki� g�c�i�in

    float dragAmount = 0.99f; // hareketi k�s�tlamakk i�in, 

    public Transform leftWheel, rightWheel;

    Vector3 _rotvec;
    Vector3 _moveVec;

    void Start()
    {
        
    }

   
    void Update()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;

        _rotvec += new Vector3(0, Input.GetAxis("Horizontal"), 0); // kullan�c�dan �nput alarak d�nd�rme i�lemi yapabiliriz.

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude); // araban�n sa�a sola d�nbmesi i�in

        _moveVec *= dragAmount;  //s�rt�nme kuvveti i�in
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed); //vekt�r�n b�y�kl���n� h�z�n� s�n�rland�r�r. parantez i�ine parametreleri yazd�k
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, Traction * Time.deltaTime) * _moveVec.magnitude; // drift yapmak i�inn 

        _rotvec =  Vector3.ClampMagnitude(_rotvec, steerAngle); // tekerle�in d�nme a��s�n� belirlemek i�n 

        leftWheel.localRotation = Quaternion.Euler(_rotvec); // tekerlek d�nd�rme i�lemi 
        rightWheel.localRotation = Quaternion.Euler(_rotvec);


    }

    //rigidbody ile s�rt�nme kuvveti ekliyebiliriz.
}
