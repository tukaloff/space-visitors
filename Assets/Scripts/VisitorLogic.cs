using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorLogic : MonoBehaviour
{
    public float visitorSpeed = 1.0f;

    private static int counter = 0;

    private ViusitorState state = ViusitorState.WAITING;
    private ChairLogic target;
    private ChairLogic setted;

    // Start is called before the first frame update
    void Start()
    {
        name += counter++;
        Registrator.registerVisitor(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (state != ViusitorState.WAITING)
            {
                if (Random.value <= 0.45f) return;
            }

            chooseAndMove();
        }
        if (state == ViusitorState.MOVING)
        {
            float step = visitorSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            if (Vector3.Distance(transform.position, target.transform.position) < 0.001f)
            {
                //target.takeThePlace();
                state = ViusitorState.SITTING;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + this.name + " => " + collision.name + " " + collision.GetComponent<ChairLogic>().isFree());
        var chair = collision.GetComponent<ChairLogic>();
        if (chair == target)
        {
            if (chair.isFree())
            {
                chair.takeThePlace();
                setted = target;
            }
            else
            {
                chooseAndMove();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (setted == collision.GetComponent<ChairLogic>())
        {
            setted.free();
            setted = null;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (state == ViusitorState.SITTING) return;
    //    Debug.Log("Trigger stay: " + this.name + " => " + collision.name + " " + collision.GetComponent<ChairLogic>().isFree());
    //    var chair = collision.GetComponent<ChairLogic>();
    //    if (chair == target)
    //    {
    //        if (chair.isFree())
    //        {
    //            chair.takeThePlace();
    //        }
    //        else
    //        {
    //            chooseAndMove();
    //        }
    //    }
    //}

    private void chooseAndMove()
    {

        if (target != null && state == ViusitorState.SITTING)
            target.free();
        target = chooseChair();
        state = ViusitorState.MOVING;
    }

    private ChairLogic chooseChair()
    {
        var freeChairs = Registrator.getFreeChairs();
        //Debug.Log(freeChairs.Count);
        var chair = freeChairs[Random.Range(0, freeChairs.Count - 1)];
        return chair;
    }
}
