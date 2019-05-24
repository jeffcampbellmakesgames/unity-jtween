# JTween

## Overview
JTween is a data-driven, job-based tweening library. It places a focus on performance by attempting to shift the processing of tween data and applying that data to tween targets on Job threads. This currently applies to Transforms only, but as the Entity-Component System of the Unity DOTS stack reaches maturity this approach can likely be applied to other components.

<img src="./images/fun_example_02.gif" alt="Example 01" height="180" width="320">
<img src="./images/fun_example_04.gif" alt="Example 02" height="180" width="320">

## Importing JCMG JTween
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

## Usage
To learn more about how to use JTween, see [here](./usage.md) for more information.

## Contributors
If you are interested in contributing, found a bug, or want to request a new feature, please see [here](./contributing.md) for more information.

## License

Please see [here](./license.md) for more information.