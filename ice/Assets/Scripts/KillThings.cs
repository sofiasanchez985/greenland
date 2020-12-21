using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour
{

    public GameObject Radar2011;
    public GameObject Radar2014;
    public GameObject Radar2015;
    public GameObject Radar2011Flipped;
    public GameObject Radar2014Flipped;
    public GameObject Radar2015Flipped;
    public GameObject CSV2011;
    public GameObject CSV2014;
    public GameObject CSV2015;
    public GameObject IceBed;
    public GameObject IceSurface;
    public GameObject Ruler;

    // Turn Radar Images On & Off

    public void KillRadar2011() { Radar2011.transform.localScale = Radar2011Flipped.transform.localScale = new Vector3(0, 0, 0); }

    public void KillRadar2014() { Radar2014.transform.localScale = Radar2014Flipped.transform.localScale = new Vector3(0, 0, 0); }

    public void KillRadar2015() { Radar2015.transform.localScale = Radar2015Flipped.transform.localScale = new Vector3(0, 0, 0); }

    public void AntiKillRadar2011() { Radar2011.transform.localScale = Radar2011Flipped.transform.localScale = new Vector3(1, 1, 1); }

    public void AntiKillRadar2014() { Radar2014.transform.localScale = Radar2014Flipped.transform.localScale = new Vector3(1, 1, 1); }

    public void AntiKillRadar2015() { Radar2015.transform.localScale = Radar2015Flipped.transform.localScale = new Vector3(1, 1, 1); }

    // Turn CSV Data On & Off

    public void KillCSV2011() { CSV2011.transform.localScale = new Vector3(0, 0, 0); }

    public void KillCSV2014() { CSV2014.transform.localScale = new Vector3(0, 0, 0); }

    public void KillCSV2015() { CSV2015.transform.localScale = new Vector3(0, 0, 0); }

    public void AntiKillCSV2011() { CSV2011.transform.localScale = new Vector3(1, 1, 1); }

    public void AntiKillCSV2014() { CSV2014.transform.localScale = new Vector3(1, 1, 1); }

    public void AntiKillCSV2015() { CSV2015.transform.localScale = new Vector3(1, 1, 1); }

    // Turn Ice Sheets & Ruler On & Off

    public void KillIceBed() { IceBed.transform.localScale = new Vector3(0, 0, 0); }

    public void KillIceSurface() { IceSurface.transform.localScale = new Vector3(0, 0, 0); }

    public void KillRuler() { Ruler.transform.localScale = new Vector3(0, 0, 0); }

    public void AntiKillIceBed() { IceBed.transform.localScale = new Vector3(0.1f, 0.05f, 0.1f); }

    public void AntiKillIceSurface() { IceSurface.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); }

    public void AntiKillRuler() { Ruler.transform.localScale = new Vector3(50, 50, 50); }

}
