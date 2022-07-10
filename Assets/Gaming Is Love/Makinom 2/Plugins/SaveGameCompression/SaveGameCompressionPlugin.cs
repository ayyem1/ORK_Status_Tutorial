
using UnityEngine;
using System.Collections.Generic;

namespace GamingIsLove.Makinom.Plugins
{
	[EditorSettingInfo("Save Game Compression", "Compress save games.")]
	public class SaveGameCompressionPlugin : BasePlugin
	{
		[EditorHelp("Compress Save Games", "Save games will be compressed.", "")]
		[EditorLabel("It's recommended to not use encryption when using compression.")]
		[EditorFoldout("Compression Settings", "The settings for save game compression.", "")]
		[EditorEndFoldout]
		public bool compressSaveGames = false;

		public SaveGameCompressionPlugin()
		{

		}

		public override string Version
		{
			get { return "1.0.0"; }
		}


		/*
		============================================================================
		Makinom callback functions
		============================================================================
		*/
		public override void OnInitialize()
		{
			if(this.compressSaveGames)
			{
				Maki.SaveGame.SetCompression(new GZipCompression());
			}
		}

		public override void OnNewGame()
		{

		}

		public override void OnLoadGame()
		{

		}

		public override void Tick()
		{

		}

		public override void GUITick()
		{

		}

		public override void SceneLoaded()
		{

		}

		public override void SceneNameLoaded(string sceneName)
		{

		}

		public override bool Call(string info)
		{
			return false;
		}
	}
}
