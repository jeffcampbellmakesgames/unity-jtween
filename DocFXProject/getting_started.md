# Overview
Getting started with JTween is a fairly straightforward process. It involves importing the plugin, adding any AssemblyDefnition references as needed, and importing its namespace into any script that you want to use the JTween API.

## Step 1 - Importing JTween
Using this library in your project can be done in two ways:
* **Releases:** The latest release can be found [here](https://github.com/jeffcampbellmakesgames/unity-jtween/releases) as a UnityPackage file that can be downloaded and imported directly into your project's Assets folder.
* **Package:** Using the native Unity Package Manager, you can add this library as a package by modifying your `manifest.json` file found at `/ProjectName/Packages/manifest.json` to include it as a dependency. See the example below on how to reference it.

```
{
	"dependencies": {
		...
		"com.jeffcampbellmakesgames.jtween" : "https://github.com/jeffcampbellmakesgames/unity-jtween.git#release/stable",
		...
	}
}
``` 

## Step 2 - Add Reference to AssemblyDefinition (optional)
Once imported, a new AssemblyDefinition `JCMG.JTween` will become available that contains the runtime JTween code. If the scripts that you need to be able to interact with JTween, they will need to add `JCMG.JTween` as a dependency. Otherwise if they are not this step can be skipped.

## Step 3 - Add JCMG.JTween Namespace to Scripts
In the scripts where you want to use JTWeen, make sure to import its namespace. All user-facing code is available in the `JCMG.JTween` namespace.

```
using JCMG.JTween;
```
