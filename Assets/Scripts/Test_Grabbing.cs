//https://www.youtube.com/watch?v=3cJ_uq1m-dg
using UnityEngine;

public class Test_Grabbing : MonoBehaviour
{
    public Transform Target;
    private Rigidbody _Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _Rigidbody.MovePosition(Target.transform.position);

    }
}
