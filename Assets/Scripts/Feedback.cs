﻿using UnityEngine;
using System.Collections;

public class Feedback : MonoBehaviour {

	public CameraShake cameraShake;
	public float cameraShakeFactor;
	public GameObject particleTrail;
	public GameObject colorExplosionPrefab;
	public ControllerFeedback controllerFeedback;
	public GameObject sprite;
	private GameObject pSys;
	public GameObject colExp;
	private Vector3 prevPos;
	private Vector3 currentDir;
	private Color startColor;
	private Color boostColorOne;
	private Color boostColorTwo;
	private Color boostColorThree;
	private Color boostColorFour;
	private Color currentColor;
	private int boostLevel = 0;
	private Tracer tracer;
	public bool showParticleTrail;
	public GameObject colorfulTrailPrefab;
	private GameObject altPSys;
	private PartnerLink partnerLink;
	private float percentToBreaking;
	private Conversation conversation;

	// Use this for initialization
	void Start () {
		if (cameraShake == null)
		{
			cameraShake = Camera.main.GetComponent<CameraShake>();
		}
		pSys = (GameObject)Instantiate(particleTrail);
		pSys.particleSystem.enableEmission = false;
		prevPos = transform.position;
		startColor = sprite.renderer.material.color;
<<<<<<< HEAD
		currentColor = startColor;
=======
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		boostColorOne = new Color(0.3f, 0.2f, 0.5f, 1.0f);
		boostColorTwo = new Color(0.3f, 0.6f, 0.3f, 1.0f);
		boostColorThree = new Color(0.95f, 0.5f, 0.0f, 1.0f);
		boostColorFour = new Color(1.0f, 1.0f, 0.0f, 1.0f);
		tracer = GetComponent<Tracer>();
		partnerLink = GetComponent<PartnerLink>();

	}
	
	// Update is called once per frame
	void Update () {
		if(altPSys == null)
		{
			pSys.transform.position = transform.position;
			pSys.particleSystem.startColor = sprite.renderer.material.color;

			currentDir = transform.position - prevPos;

			pSys.particleSystem.emissionRate = (currentDir.magnitude/Time.deltaTime)*2;

			currentDir.Normalize();


			if(currentDir.sqrMagnitude != 0)
				pSys.transform.rotation = Quaternion.LookRotation(-currentDir, pSys.transform.up);
			prevPos = transform.position;
		}
		else
		{
			altPSys.transform.position = transform.position;
			
			currentDir = transform.position - prevPos;
			
			altPSys.particleSystem.emissionRate = (currentDir.magnitude/Time.deltaTime)*10;
			
			currentDir.Normalize();
	
			if(currentDir.sqrMagnitude != 0)
				altPSys.transform.rotation = Quaternion.LookRotation(-currentDir, altPSys.transform.up);
			prevPos = transform.position;
		}

		if(partnerLink.Partner != null)
		{
			conversation = ConversationManger.Instance.FindConversation(partnerLink, partnerLink.Partner);
			percentToBreaking = ((transform.position - partnerLink.Partner.transform.position).sqrMagnitude)/conversation.breakingDistance;

			sprite.renderer.material.color = currentColor;
			percentToBreaking = 1 - percentToBreaking;

			float red = sprite.renderer.material.color.r*percentToBreaking;
			float green = sprite.renderer.material.color.g*percentToBreaking;
			float blue = sprite.renderer.material.color.b*percentToBreaking;

			sprite.renderer.material.color = new Color(red, green, blue);
		}

		if(currentDir.magnitude <= 0.01f)
		{
			boostLevel = 0;
			sprite.renderer.material.color = startColor;
		}
	}

	void SpeedBoost()
	{
		if (cameraShake != null)
		{
<<<<<<< HEAD
			if(colExp == null)
				cameraShake.ShakeCamera(cameraShakeFactor);
		}
		if (controllerFeedback != null) 
		{
			controllerFeedback.SetVibration(0.5f, 0.5f);
=======

			cameraShake.ShakeCamera(cameraShakeFactor);
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		}
		if (controllerFeedback != null) 
		{
			controllerFeedback.SetVibration(0.5f, 0.5f);
		}
		ChangeBoost(1);
	}

	void SpeedDrain()
	{
		ChangeBoost(-1);
	}

	void SpeedNormal()
	{
		if (cameraShake != null)
		{
			cameraShake.StopShaking();
		}
	}

	private void ChangeBoost(int levelChange)
	{
		boostLevel = Mathf.Clamp(boostLevel + levelChange, 0, 4);
		if (boostLevel == 4)
		{
			sprite.renderer.material.color = boostColorFour;
<<<<<<< HEAD
			currentColor = boostColorFour;
=======
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		}
		else if (boostLevel == 3)
		{
			sprite.renderer.material.color = boostColorThree;
<<<<<<< HEAD
			currentColor = boostColorThree;
=======
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		}
		else if (boostLevel == 2)
		{
			sprite.renderer.material.color = boostColorTwo;
<<<<<<< HEAD
			currentColor = boostColorTwo;
=======
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		}
		else if (boostLevel == 1)
		{
			sprite.renderer.material.color = boostColorOne;
<<<<<<< HEAD
			currentColor = boostColorOne;
=======
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
		}
		else if (boostLevel == 0)
		{
			sprite.renderer.material.color = startColor;
<<<<<<< HEAD
			currentColor = startColor;
		}
		tracer.lineRenderer.material.color = sprite.renderer.material.color;
		if(colExp == null)
		{
			colExp = (GameObject)Instantiate(colorExplosionPrefab);
			colExp.particleSystem.startColor = sprite.renderer.material.color;
			colExp.transform.position = transform.position;
			Destroy(colExp, 3.1f);
		}
=======
		}
		tracer.lineRenderer.material.color = sprite.renderer.material.color;
		colExp = (GameObject)Instantiate(colorExplosionPrefab);
		colExp.particleSystem.startColor = sprite.renderer.material.color;
		colExp.transform.position = transform.position;
		Destroy(colExp, 3.1f);
>>>>>>> b18246a33356c4de08256a233f49aa5b0444e615
	}

	private void EnterWake()
	{
		if (!pSys.particleSystem.enableEmission)
		{
			pSys.particleSystem.enableEmission = true;
		}
	}

	private void ExitWake()
	{
		if (pSys.particleSystem.enableEmission)
		{
			pSys.particleSystem.enableEmission = false;
		}
	}

	public void AlternateTrail(){
		if (altPSys == null)
		{
			altPSys = (GameObject)Instantiate(colorfulTrailPrefab);
			altPSys.transform.position = transform.position;
		}
	}
}
