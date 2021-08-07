using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{

    #region Main 

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    #endregion

}
