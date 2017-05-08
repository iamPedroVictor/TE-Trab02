using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {


    //Public variables
    public float maxSpeed = 5f;
    public float speed = 2f;
    public float rotSpeed = 180f;

    //Private Components
    private Rigidbody2D rb2D;
    private Transform tf;

    private Vector2 velocity;
	public int indx;
    public PlayerInput input;

    public Weapon weapon;

    [Header("Atributos")]
    public float maxLifePoint;
    public float currentLifePoint;

    public bool isDie;

    private Animator anim;

    public UIControl uiPlayer;

	public PlayerInput getInput(){
		return input;
	}

    

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        input = new PlayerInput();
        uiPlayer = new UIControl();
		input.Init(indx, ControllerMaps.Xbox);
		string[] joy = Input.GetJoystickNames ();

        anim = GetComponent<Animator>();

		Debug.Log ("Conectados: " + joy.Length);
		foreach (string s in joy) {
			Debug.Log (s);

		}
        uiPlayer.Enable(indx,maxLifePoint);
        currentLifePoint = maxLifePoint;

        weapon.soundControl = GetComponent<SoundControl>();

        isDie = false;


    }


    // Update is called once per frame
    void Update () {

        if (GameManager.Instance.gameStatus != GameStatus.GamePlay || isDie)
            return;

        //Rotate the ship
        //Pegando a rotação da nave
        Quaternion rot = tf.rotation;

        //Pegando o euler angle Z
        float z = rot.eulerAngles.z;

        //Change the Z angle based input
		z -= input.GetAxisJoystickX() * rotSpeed * Time.deltaTime;

        //recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;

        //Move Ship
        Vector3 pos = tf.position;
        

        Vector2 velocity = new Vector3(0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;

        pos += rot * velocity;

         tf.position = pos;

        if (!input.Enable) return;

        float h = input.GetAxisJoystickX();
        float v = input.GetAxisJoystickY();

        if (input.GetButtonPress(ButtonActions.Fire))
        {
            weapon.Shoot(indx);
            
        }

    }

    public void LifeUpdate(float point) {

        if(point > 0){
            if (currentLifePoint + point > maxLifePoint){
                currentLifePoint = maxLifePoint;
            }
                
        }else if (point < 0){
            if(currentLifePoint + point < 0){
                currentLifePoint = 0;
            }
        }

        currentLifePoint += point;

        this.uiPlayer.UpdateBar(currentLifePoint);
        VerifyDie();
    }

    public void DeathStatus() {
        GameManager.Instance.Die(indx);
        gameObject.SetActive(false);
        
    }

    private void VerifyDie()
    {
        if(currentLifePoint <= 0){
            isDie = true;
            anim.SetBool("Die", isDie);
            DeathStatus();
        }
    }


}
