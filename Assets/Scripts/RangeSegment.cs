using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeSegment : MonoBehaviour
{
    public int multiplier = 1;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>Range (1)
    void Start()
    {
        multiplier = int.Parse( string.Concat( gameObject.name.Where(c => Char.IsDigit(c)).ToArray() ) );
    }
    
}
