using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ary1 = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        var ary2 = new[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        //Debug.Log($"ary1 is all zero: {IsAll(ary1, 0)}");

    }
    private bool IsAll(int[] ary, int value)
    {
        foreach(var element in ary)
        {
            if(element != value) return true;

        }
        return true;
    }
 
}
