using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour // ��ź�� ��� �ִ� ���
{
    [SerializeField] GameObject bulletPrefab; // ������ �������� : GameObject bulletPrefab ��
    [SerializeField] Transform firePoint; // ��𿡼� �߻����� : firePoint ����

    [Range(0f, 50f)] // �ּҰ� �ִ밪
    [SerializeField] float fireSpeed; // ������� �ӵ��� ���ư���
    public void Shoot() // ������ �ൿ���� : Shoot(��ź �߻�)
    {
        GameObject instance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // �����ɶ� : bulletPrefab�� ��ġ�� firePoint.position , firePoint.rotation
        Rigidbody rigidbody = instance.GetComponent<Rigidbody>(); // ��ź�ȿ� �ִ� Rigidbody ��������

        rigidbody.velocity = firePoint.forward * fireSpeed; // ��ź�� �չ��� (firePoint.forward)���� ��ź�� ���ǵ� (fireSpeed) ��ŭ

        Destroy(instance, 3); // 3�ʵڿ� ���� (Destroy)
    }

    public void Shoot(float speed) // ������ �ൿ���� : Shoot(��ź �߻�)
    {
        GameObject instance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // �����ɶ� : bulletPrefab�� ��ġ�� firePoint.position , firePoint.rotation
        Rigidbody rigidbody = instance.GetComponent<Rigidbody>(); // ��ź�ȿ� �ִ� Rigidbody ��������

        rigidbody.velocity = firePoint.forward * speed; // ��ź�� �չ��� (firePoint.forward)���� ��ź�� ���ǵ� (fireSpeed) ��ŭ

        Destroy(instance, 3); // 3�ʵڿ� ���� (Destroy)
    }



}
