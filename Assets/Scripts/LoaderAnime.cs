﻿using UnityEngine;

	public class LoaderAnime : MonoBehaviour {

		#region Public Variables

		[Tooltip("Angular Speed in degrees per seconds")]
		public float speed = 180f;

		[Tooltip("Radius os the loader")]
		public float radius = 1f;

		public GameObject particles;

		#endregion
		
		#region Private Variables

		Vector3 _offset;

		Transform _transform;

		Transform _particleTransform;

		bool _isAnimating;

		#endregion
		
		#region MonoBehaviour CallBacks
		
		void Awake()
		{
			// cache for efficiency
			_particleTransform =particles.GetComponent<Transform>();
			_transform = GetComponent<Transform>();
		}

		
		void Update () {

			// only care about rotating particles if we are animating
			if (_isAnimating)
			{
				// we rotate over time. Time.deltaTime is mandatory to have a frame rate independant animation,
				_transform.Rotate(0f,0f,speed*Time.deltaTime);
				
				// we move from the center to the desired radius to prevent the visual artifacts of particles jumping from their current spot, it's not very nice visually
				// so the particle is centered in the scene so that when it starts rotating, it doesn't jump and slowy we animate it to its final radius giving a smooth transition.
				_particleTransform.localPosition = Vector3.MoveTowards(_particleTransform.localPosition, _offset, 0.5f*Time.deltaTime);
			}
		}
		#endregion

		#region Public Methods

		/// <summary>
		/// Starts the loader animation. Becomes visible
		/// </summary>
		public void StartLoaderAnimation()
		{
			_isAnimating = true;
			_offset = new Vector3(radius,0f,0f);
			particles.SetActive(true);
		}

		/// <summary>
		/// Stops the loader animation. Becomes invisible
		/// </summary>
		public void StopLoaderAnimation()
		{
			particles.SetActive(false);
		}

		#endregion
	}