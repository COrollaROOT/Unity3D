using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour // 포탄을 쏠수 있는 기능
{
    [SerializeField] GameObject bulletPrefab; // 무엇을 생성할지 : GameObject bulletPrefab 를
    [SerializeField] Transform firePoint; // 어디에서 발사할지 : firePoint 에서

    [Range(0f, 50f)] // 최소값 최대값
    [SerializeField] float fireSpeed; // 어느정도 속도로 날아갈지
    public void Shoot() // 무엇을 행동할지 : Shoot(포탄 발사)
    {
        GameObject instance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // 생성될때 : bulletPrefab를 위치는 firePoint.position , firePoint.rotation
        Rigidbody rigidbody = instance.GetComponent<Rigidbody>(); // 포탄안에 있는 Rigidbody 가져오기

        rigidbody.velocity = firePoint.forward * fireSpeed; // 포탄의 앞방향 (firePoint.forward)으로 포탄의 스피드 (fireSpeed) 만큼

        Destroy(instance, 3); // 3초뒤에 삭제 (Destroy)
    }

    public void Shoot(float speed) // 무엇을 행동할지 : Shoot(포탄 발사)
    {
        GameObject instance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // 생성될때 : bulletPrefab를 위치는 firePoint.position , firePoint.rotation
        Rigidbody rigidbody = instance.GetComponent<Rigidbody>(); // 포탄안에 있는 Rigidbody 가져오기

        rigidbody.velocity = firePoint.forward * speed; // 포탄의 앞방향 (firePoint.forward)으로 포탄의 스피드 (fireSpeed) 만큼

        Destroy(instance, 3); // 3초뒤에 삭제 (Destroy)
    }



}
