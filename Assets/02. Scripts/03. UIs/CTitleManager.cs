using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CTitleManager : MonoBehaviour {
	public Text m_uiTextLog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WRITELOG(string strMsg)
	{
		m_uiTextLog.text = strMsg;
	}
}
