using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GunController : MonoBehaviour
{
    public static GunController _gunController;

    GameObject bulletRight;
    GameObject bulletLeft;
    GameObject fireParticle;
    GameObject kovan;
    [SerializeField] GameObject mainBulletRight;
    [SerializeField] GameObject mainBulletLeft;
    [SerializeField] GameObject fireParticleforTransform;
    [SerializeField] GameObject KovanforTransform;
    public int bulletSpeed;

    Rigidbody bulletRightRb;
    Rigidbody bulletLeftRb;
    bool CanFire;
    void Start()
    {
        CanFire = true;
        _gunController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    Tween GeriTepme;
    public void Fire()
    {
        if (CanFire)
        {
            GameManagement.Instance.atilanMermi += 2;
            bulletRight = ObjectPooler.Instance.SpawnFromPool("BulletRight", mainBulletRight.transform.position, mainBulletRight.transform.rotation);
            bulletLeft = ObjectPooler.Instance.SpawnFromPool("BulletLeft", mainBulletLeft.transform.position, mainBulletLeft.transform.rotation);
            fireParticle = ObjectPooler.Instance.SpawnFromPool("FireParticle", fireParticleforTransform.transform.position, fireParticleforTransform.transform.rotation);
            kovan = ObjectPooler.Instance.SpawnFromPool("Kovan", KovanforTransform.transform.position, KovanforTransform.transform.rotation);
            kovan.transform.DOJump(new Vector3(kovan.transform.position.x - 0.2f, -1, kovan.transform.position.z), 1f, 1, 0.5f);
            GeriTepme = transform.DOLocalMoveZ(2.75f, 0.2f).OnComplete(() =>
            {
                transform.DOLocalMoveZ(3.43f, 0.2f);
            });
            CanFire = false;
            bulletRightRb = bulletRight.GetComponent<Rigidbody>();
            bulletLeftRb = bulletLeft.GetComponent<Rigidbody>();
            bulletRightRb.AddForce(transform.forward * bulletSpeed);
            bulletLeftRb.AddForce(transform.forward * bulletSpeed);
            StartCoroutine(ClosePoolObject());
        }
        
    }

    IEnumerator ClosePoolObject()
    {
        yield return new WaitForSeconds(0.4f);
        GeriTepme.Kill();
        CanFire = true;
        yield return new WaitForSeconds(5);
        fireParticle.SetActive(false);
        kovan.SetActive(false);
    }
}
