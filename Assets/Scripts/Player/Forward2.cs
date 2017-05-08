using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward2 : MonoBehaviour {

    public Vector3 direction = Vector3.right;
    public float rotationSpeed = 45f;
    public Rigidbody2D rbd2d;
    public float speed;
	public PlayerInput playerInput;

    public SoundControl soundControl;

    public ParticleSystem particle;
    [SerializeField]
    private bool isBoost;

    private Vector2 maxVelocity;

    private void Start(){
		playerInput = GetComponent<Player> ().getInput ();
        soundControl = GetComponent<SoundControl>();
        isBoost = false;
        if (particle.isPlaying && particle != null)
            particle.Stop();
	}


    void Update()
    {
        if (GameManager.Instance.gameStatus != GameStatus.GamePlay)
            return;

        if (playerInput.GetButtonPress(ButtonActions.Boost))
        {
            rbd2d.AddForce(transform.up * speed);
            isBoost = true;

        }else
        {
            if (particle.isPlaying)
            {
                particle.Stop();

            }
            if (rbd2d.velocity.x > maxVelocity.x)
                return;
            if (rbd2d.velocity.x < -maxVelocity.x)
                return;
            if (rbd2d.velocity.y > maxVelocity.y)
                return;
            if (rbd2d.velocity.y < -maxVelocity.y)
                return;
            rbd2d.velocity = SlowBoost(rbd2d.velocity);

            isBoost = false;
            
        }
        if (playerInput.GetButtonDown(ButtonActions.Boost))
        {
            soundControl.ApplySound("Boost");
            if (!particle.isPlaying){
                particle.Play();
                
            }

        }

        Vector3 position = transform.position;
		Debug.DrawLine(position, position + direction, Color.red);
		Debug.DrawLine(position, position + transform.up, Color.green);
    }


    private Vector2 SlowBoost(Vector2 velocity)
    {
        Vector2 lowBoost;
        lowBoost = velocity * .5f;
        print(lowBoost);
        return lowBoost;
    }

}
