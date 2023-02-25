using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic.Enums;
[CreateAssetMenu]
public class BallSo : ScriptableObject
{
    #region Fields
    [SerializeField]
    public string ballNumber;
    public BallType ballType;
    #endregion
    
}
