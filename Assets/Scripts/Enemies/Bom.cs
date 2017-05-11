using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : Enemy
{
    public SphereCollider explodeRad;
    public GameObject onSelfDestruct;
    public float explosionDelay = 2f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    protected override void Attack()
    {
        StartCoroutine(StartDestruction(explosionDelay));
        
    }

    IEnumerator StartDestruction(float delay)
    {
        
        anim.SetTrigger("Explode");

        
        yield return new WaitForSeconds(delay);

        
        if (IsAtTarget())
        {
            SelfDestruct();
        }
        else
        {
            
            anim.SetTrigger("Deactivate");
        }



    }

    void SelfDestruct()
    {
        PlayExplosion();
        Explode();
        DestroyObject(gameObject);
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(onSelfDestruct);
        explosion.transform.position = transform.position;
    }

    void Explode()
    {
        
        Collider[] hits = Physics.OverlapSphere(explodeRad.transform.position, explodeRad.radius * explodeRad.transform.localScale.magnitude);

        
        for (int i = 0; i < hits.Length; i++)
        {
            Collider hit = hits[i];
            Characters character = hit.GetComponent<Characters>();
            if (character != null)
            {
                
                character.health -= damage;
            }
        }
    }

}
