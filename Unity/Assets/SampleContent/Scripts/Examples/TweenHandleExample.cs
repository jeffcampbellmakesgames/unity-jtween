using JCMG.JTween;
using UnityEngine;
using UnityEngine.UI;

namespace SampleContent
{
	public class TweenHandleExample : MonoBehaviour
	{
		[Header("Scene Refs")]
		[SerializeField]
		private GameObject _moveObject;

		[SerializeField]
		private Vector3 _destination;

		[Header("Scene Refs")]
		[Space(5)]
		[SerializeField]
		private Button _playButton;

		[SerializeField]
		private Button _pauseButton;

		[SerializeField]
		private Button _restartButton;

		[SerializeField]
		private Button _rewindButton;

		[SerializeField]
		private Button _stopButton;

		[SerializeField]
		private Button _recycleButton;

		private Vector3 _originalPosition;
		private ITweenHandle _tweenHandle;

		private void Start()
		{
			_playButton.onClick.AddListener(OnPlayButtonClicked);
			_pauseButton.onClick.AddListener(OnPauseButtonClicked);
			_restartButton.onClick.AddListener(OnRestartButtonClicked);
			_rewindButton.onClick.AddListener(OnRewindButtonClicked);
			_stopButton.onClick.AddListener(OnStopButtonClicked);
			_recycleButton.onClick.AddListener(OnRecycleButtonClicked);

			_originalPosition = _moveObject.transform.position;
		}

		private void OnPlayButtonClicked()
		{
			if (_tweenHandle == null)
			{
				// This movement tween will move this transform in world space to the target area.
				_moveObject.transform.Move(
					_originalPosition,
					_destination,
					2,
					out _tweenHandle,
					EaseType.BounceOut);

				_tweenHandle.AddOnStartedListener(OnTweenStarted);
				_tweenHandle.AddOnCompletedListener(OnTweenCompleted);
				_tweenHandle.Play();
			}
			else
			{
				_tweenHandle.Play();
			}
		}

		private void OnPauseButtonClicked()
		{
			if (_tweenHandle != null)
			{
				_tweenHandle.Pause();
			}
			else
			{
				Debug.Log("Tween needs to be created first via Play button before trying to pause it.");
			}
		}

		private void OnRestartButtonClicked()
		{
			if (_tweenHandle != null)
			{
				_tweenHandle.Restart();
			}
			else
			{
				Debug.Log("Tween needs to be created first via Play button before trying to restart it.");
			}
		}

		private void OnRewindButtonClicked()
		{
			if (_tweenHandle != null)
			{
				_tweenHandle.Rewind();
			}
			else
			{
				Debug.Log("Tween needs to be created first via Play button before trying to rewind it.");
			}
		}

		private void OnStopButtonClicked()
		{
			if (_tweenHandle != null)
			{
				_tweenHandle.Stop();
			}
			else
			{
				Debug.Log("Tween needs to be created first via Play button before trying to stop it.");
			}
		}

		private void OnRecycleButtonClicked()
		{
			if (_tweenHandle != null)
			{
				_tweenHandle.Recycle();
				_tweenHandle = null;
			}
			else
			{
				Debug.Log("Tween needs to be created first via Play button before trying to recycle it.");
			}
		}

		private void OnTweenStarted()
		{
			Debug.Log("Tween Started");
		}

		private void OnTweenCompleted()
		{
			Debug.Log("Tween Completed");
		}

		private void OnDrawGizmos()
		{
			if (_moveObject == null)
			{
				return;
			}

			Gizmos.color = Color.green;
			Gizmos.DrawLine(_moveObject.transform.position, _destination);
		}
	}
}
