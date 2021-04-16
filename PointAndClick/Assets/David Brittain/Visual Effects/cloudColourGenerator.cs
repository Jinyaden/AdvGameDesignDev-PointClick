using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class cloudColourGenerator : MonoBehaviour
{
    [SerializeField]
    private VisualEffect vfx;

    [SerializeField]
    private Gradient gradientCloud = null;

    [SerializeField]
    private Gradient colourCloud1;

    [SerializeField]
    private Gradient colourCloud2;

    [SerializeField]
    private Gradient colourCloud3;

    GradientColorKey[] colourKey;
    GradientAlphaKey[] alphaKey;
    
    public Gradient currentColourOfCloud
    {
        get { return gradientCloud; }
        set { gradientCloud = value; }
    }

     void Start()
    {
        gradientCloud = new Gradient();

        colourKey = new GradientColorKey[3];
        colourKey[0].color = Color.white;
        colourKey[1].color = Color.grey;
        colourKey[2].color = Color.black;

        alphaKey = new GradientAlphaKey[0];

        int newcolourofCloud;
        newcolourofCloud = Random.Range(1, 3);
        if (newcolourofCloud == 1)
        {
            currentColourOfCloud = colourCloud1;
        }
        if (newcolourofCloud == 2)
        {
            currentColourOfCloud = colourCloud2;
        }
        if (newcolourofCloud == 3)
        {
            currentColourOfCloud = colourCloud3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vfx.SetGradient("colourCloud", gradientCloud);
        vfx.SetGradient("First colour of cloud", colourCloud1);
        vfx.SetGradient("Second colour of cloud", colourCloud2);
        vfx.SetGradient("Third colour of cloud", colourCloud3);

    }
}
