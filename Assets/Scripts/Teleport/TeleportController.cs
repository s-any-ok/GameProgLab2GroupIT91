using UnityEngine;
using UnityEngine.SceneManagement;

namespace Teleport
{
	public class TeleportController : MonoBehaviour
	{
		[SerializeField] private string _sceneName;
		[SerializeField] private string _triggerName;

		private void OnTriggerEnter(Collider collider)
		{
			if (collider.name == _triggerName)
			{
				SceneManager.LoadScene(_sceneName);
			}
		}
	}
}
