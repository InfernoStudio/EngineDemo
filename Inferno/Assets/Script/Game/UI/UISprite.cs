using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.U2D;
[RequireComponent(typeof(Image))]
public class UISprite : MonoBehaviour
{
	public SpriteAtlas atlas;
	public Image image;
	public void SetSprite(string spriteName)
	{
		image.sprite = atlas.GetSprite(spriteName);
		if (image.sprite == null)
			Debug.LogError(string.Format("Sprite with name {0} is not present in the atlas",spriteName));
	}

}
