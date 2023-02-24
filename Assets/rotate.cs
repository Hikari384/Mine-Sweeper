using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    bool Xrota = false;
    bool Yrota = false;
    bool Zrota = false;

    [SerializeField] private float x = 180;
    [SerializeField] private float y = 180;
    [SerializeField] private float z = 180;

     private float t = 0;
     private float tt = 0;
    [SerializeField] float select = 1;
    [SerializeField] float stopRotate = 2;
     int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        var e = Rotate(new(1, 0, 0), 2);
        StartCoroutine(Run());
       
    }

    // Update is called once per frame
    void Update()
    {
        //Run() これだとコルーチンは実行されない


        //if (!Xrota && !Yrota && !Zrota)
        //{
        //    t += Time.deltaTime;
        //}
        //if (t > select)
        //{
        //    t = 0;
        //    a = Random.Range(0, 3);
        //}
        //if (a == 0)
        //{
        //    Xrota = true;
        //}
        //if (a == 1)
        //{
        //    Yrota = true;
        //}
        //if(a == 2)
        //{
        //    Zrota= true;
        //}
        //if(Xrota == true)
        //{
        //    transform.Rotate(new Vector3(x, 0, 0), Space.World);      
        //    tt+= Time.deltaTime;
        //}
        //if (Yrota == true)
        //{
        //    transform.Rotate(new Vector3(0, y, 0), Space.World);
        //    tt += Time.deltaTime;
        //} 
        //if (Zrota == true)
        //{
        //   transform.Rotate(new Vector3(0, 0, z), Space.World);
        //    tt += Time.deltaTime;

        //}
        //if(tt > stopRotate) {
        //    a = 5;
        //    tt = 0;
        //    Xrota= false;
        //    Yrota = false;
        //    Zrota = false;
        //}  
    }
    private IEnumerator Run()
    {
        while (true)
        {
            yield return Rotate(Vector3.right, 2);
            //次のフレームはyield returnの続きから実行される

            yield return WaitClick();
          
            yield return Rotate(Vector3.up, 2);

            yield return WaitClick(); 
          
            yield return Rotate(Vector3.forward, 2);

            yield return WaitClick();





        }
    }

    private IEnumerator Rotate(Vector3 axis, float time)
    {
        time = 0f;
        while (time < 2)
        {
            time += Time.deltaTime;
            transform.Rotate(axis, Space.World);
            yield return null;
        }
    }
    private IEnumerator WaitClick() 
    {

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
       
    }

}
