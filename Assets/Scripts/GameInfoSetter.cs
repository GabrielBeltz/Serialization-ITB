using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoSetter : MonoBehaviour
{
    public bool rustingHulks;

    public Run baseRunToSave
    {
        get
        {
            if (rustingHulks)
            {
                return RustingHulksRun;
            }
            else
            {
                return customRun;
            }
        }
        protected set
        {
        }
    }
    public Run RustingHulksRun;
    public Run customRun;
}
