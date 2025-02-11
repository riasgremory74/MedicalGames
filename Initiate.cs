using UnityEngine;
using System.Collections;

public static class Initiate {
    //Create Fader object and assing the fade scripts and assign all the variables
    public static void Fade(string scene,Color col,float damp)
    {
        GameObject init = new GameObject();
        init.name = "Fader";
        init.AddComponent<Fader>();
        Fader scr = init.GetComponent<Fader>();
        scr.fadeDamp = damp;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start = true;
    }
    public static void Fade (string scene){
        float damp = 8f;
        Color col = new Color(0.2f, 0.231f, 0.25f,1f);
        GameObject init = new GameObject ();
		init.name = "Fader";
		init.AddComponent<Fader> ();
		Fader scr = init.GetComponent<Fader> ();
		scr.fadeDamp = damp;
		scr.fadeScene = scene;
		scr.fadeColor = col;
		scr.start = true;
	}
    public static void Fade()
    {
        float damp = 8f;
        Color col = new Color(0.89f, 0.89f, 0.89f, 1);
        GameObject init = new GameObject();
        init.name = "Fader";
        init.AddComponent<Fader>();
        Fader scr = init.GetComponent<Fader>();
        scr.fadeDamp = damp;
        scr.fadeColor = col;
        scr.start = true;
    }
}

