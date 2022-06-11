using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SolBacak")
        {
            StartCoroutine(AnimatorCloseandOpen());
            GameManagement.Instance.Healt -= 20;
            //particle
            if (GameManagement.Instance.Healt > 20)
            {
                StartCoroutine(AnimatorCloseandOpen());
            }
        }
        if (other.gameObject.tag == "SaðBacak")
        {
            GameManagement.Instance.Healt -= 20;
            //particle
            if (GameManagement.Instance.Healt > 20)
            {
                StartCoroutine(AnimatorCloseandOpen());
            }
        }
        if (other.gameObject.tag == "Gogus")
        {
            print("göðüsten vuruldu");
            GameManagement.Instance.Healt -= 40;
            //particle
            if (GameManagement.Instance.Healt > 20)
            {
                StartCoroutine(AnimatorCloseandOpen());
            }
        }
        if (other.gameObject.tag == "Kafa")
        {
            GameManagement.Instance.Healt -= 80;
            //particle
            if (GameManagement.Instance.Healt > 20)
            {
                StartCoroutine(AnimatorCloseandOpen());
            }
        }

    }
    IEnumerator AnimatorCloseandOpen()
    {
        GameManagement.Instance.ragdollObject.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GameManagement.Instance.ragdollObject.GetComponent<Animator>().enabled = true;
        yield return null;
    }
}
