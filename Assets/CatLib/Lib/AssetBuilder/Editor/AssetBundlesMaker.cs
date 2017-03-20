﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */
 
using UnityEditor;
using System;
using System.Collections.Generic;
using CatLib.API.AssetBuilder;

namespace CatLib.AssetBuilder
{

	public class AssetBundlesMaker{

        /// <summary>
        /// 编译Asset Bundle
        /// </summary>
        [MenuItem ("CatLib/Asset Builder/Build Current Platform")]
		public static void BuildAllAssetBundles ()
		{

			List<IBuildStrategy> strategys = new List<IBuildStrategy>();

			foreach(Type t in typeof(IBuildStrategy).GetChildTypesWithInterface()){
				
				strategys.Add(App.Instance.Make(t.ToString()) as IBuildStrategy);

			}
		
			strategys.Sort(	(left , right) => ((int)left.Process).CompareTo((int)right.Process));
			
			var context = new BuildContext();
			foreach(IBuildStrategy buildStrategy in strategys.ToArray()){

				buildStrategy.Build(context);

			}


	
			/* 
			RuntimePlatform switchPlatform = Env.SwitchPlatform;
			string platform = Env.PlatformToName(switchPlatform);

            ClearAssetBundle();
            BuildAssetBundleName(Env.DataPath + Env.ResourcesBuildPath);
			string releasePath = Env.DataPath + Env.ReleasePath + IO.IO.PATH_SPLITTER + platform;			
			IDirectory releaseDir = CatLib.IO.IO.MakeDirectory(releasePath);

            releaseDir.Delete();
			releaseDir.Create();

			IDirectory copyDire = CatLib.IO.IO.MakeDirectory(Env.DataPath + Env.ResourcesNoBuildPath);
			copyDire.CopyTo(Env.DataPath + Env.ReleasePath + IO.IO.PATH_SPLITTER + platform);

			BuildPipeline.BuildAssetBundles("Assets" + Env.ReleasePath + IO.IO.PATH_SPLITTER + platform, 
												BuildAssetBundleOptions.None ,
                                                PlatformToBuildTarget(switchPlatform));

            BuildListFile(releasePath);

			AssetDatabase.Refresh();*/
		}


		

	}

}