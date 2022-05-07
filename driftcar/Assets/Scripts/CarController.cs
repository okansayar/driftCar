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
    float steerAngle; //açýyla dönme iþlemi için.

    [SerializeField]
    float Traction; // çekiþ gücüiçin

    float dragAmount = 0.99f; // hareketi kýsýtlamakk için, 

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

        _rotvec += new Vector3(0, Input.GetAxis("Horizontal"), 0); // kullanýcýdan ýnput alarak döndürme iþlemi yapabiliriz.

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude); // arabanýn saða sola dönbmesi için

        _moveVec *= dragAmount;  //sürtünme kuvveti için
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed); //vektörün büyüklüðünü hýzýný sýnýrlandýrýr. parantez içine parametreleri yazdýk
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, Traction * Time.deltaTime) * _moveVec.magnitude; // drift yapmak içinn 

        _rotvec =  Vector3.ClampMagnitude(_rotvec, steerAngle); // tekerleðin dönme açýsýný belirlemek içn 

        leftWheel.localRotation = Quaternion.Euler(_rotvec); // tekerlek döndürme iþlemi 
        rightWheel.localRotation = Quaternion.Euler(_rotvec);


    }

    //rigidbody ile sürtünme kuvveti ekliyebiliriz.
}
