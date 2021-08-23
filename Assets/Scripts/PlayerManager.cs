using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected Joystick joystick;
    protected FixedButton fixedButton;
    // Start is called before the first frame update
    void Start()
    {
        joystick=FindObjectOfType<Joystick>();
        fixedButton= FindObjectOfType<FixedButton>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
                    transform.position.x + joystick.Horizontal*0.15f,
                    transform.position.y,
                    transform.position.z+joystick.Vertical*0.15f);
        /*var rigidbody=GetComponent<Rigidbody>();
        rigidbody.velocity=new Vector3( joystick.Horizontal*10f,
                                        rigidbody.velocity.y,
                                        joystick.Vertical*10f);*/
    }
}
