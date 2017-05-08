using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : PoolObject {

	public Rigidbody2D rb2D;
	public float speed;
    [SerializeField]
    private float timeToDestroy;
    public float damage;

    public string myIndexPlayer;

	public void Shoot(){

		rb2D.GetComponent<Rigidbody2D> ();
		rb2D.AddForce (transform.up * speed );
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null){
            if(!player.CompareTag(myIndexPlayer)){
                player.LifeUpdate(damage);
                Destroy();
            }
            
        }

        

    }

    public override void OnObjectReuse()
    {
        Shoot();
        Invoke("Destroy", timeToDestroy);
        rb2D.GetComponent<Rigidbody2D>();
    }



}
