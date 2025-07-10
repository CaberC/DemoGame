using UnityEngine;

namespace  Caber.DemoGame.Player;
public class PlayerMove : MonoBehaviour
{
    //_rigid body is a private constant tie the rigidbody to the rest of the player
    private const Rigidbody _rigidbody;
    
    /* Start runs when the script is called
     in: void
     out: void
     throws: none
     */
    void Start()
    {
        
    }

    /* Awake runs when the script is initialized
     in: void
     out: void
     throws: none
     */
    void Awake()
    {
        rigidbody = getComponent<Rigidbody>();
    }

    /* Update runs every frame
     in: void
     out: void
     throws: none
     */
    void Update()
    {
        
    }
    
    /* FixedUpdate runs when the script is initialized
     in: void
     out: void
     throws: none
     */
    void FixedUpdate()
    {
        
    }
}
