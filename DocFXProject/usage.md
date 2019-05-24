# Overview

Using JTween should be a straightforward experience if you've ever used similar tween libraries for Unity, despite the complex underlying implementation. The biggest difference which I'll cover in more detail below is that this library de-emphasizes returning any kind of OOP access to the tween itself; for the most part when tweens are created they automaticaly begin playing and will clean themselves up automatically once completed. It is stil possible however to get a reference object to the tween itself in the form of an `ITweenHandle` which allows for more standard user-control over the tween itself; this comes with the responsibility over its lifecycle and requires user action when the tween is no longer needed.

## Adding JTweenControl

`JTweenControl` is a global tween manager component which ultimately all tween calls are routed through and managed by. This can be added to an existing scene at edit time by:
* Using the the `Add Component` menu to add it to an existing `GameObject`.
* Using the menu item _Tools->JTween->Add JTweenControl to Scene_. This will add the component to the scene on a new `GameObject` named _JTweenControl_ if it does not already exist.

If at runtime `JTweenControl` does not exist, it will be created the first time any type of tween is created.

## Creating Tweens

Creating tweens can be done by either using the provided extension methods which offer a variety of specific ways of animating transforms or by making calls directly to `JTweenControl.Instance` which offers all of the tweening methods that are available with all parameters. The example below covers the same tween data, but shows how they vary when created through extension methods or `JTweenControl` directly.

### Extension method example

The extension methods for tweens generally focus on a specific type of tween transformation to simplify the API and require less mandatory parameters.

```
// This movement tween will move this transform in local space relative to its parent to the target over 2 seconds
// with a BounceOut ease type and will loop 5 times from the beginning.
transform.MoveLocal(new Vector3(10, 0, 0), 2, EaseType.BounceOut, LoopType.Restart, 5);
```

### JTweenControl example

The methods for tweening on `JTweenControl` provide all the possible parameters for a tween transformation. Default values are provided to help simplify calling these methods, but for specific type of transformations (Local vs World) certain parameters like `SpaceType` must be provided to set the correct transformation behavior.

```
// This movement tween will move this transform in local space relative to its parent to the target over 2 seconds
// with a BounceOut ease type and will loop 5 times from the beginning.
JTweenControl.Instance.Move(
				transform,
				transform.localPosition,
				transform.localPosition + new Vector3(10,0,0),
				2,
				SpaceType.Local,
				EaseType.BounceOut,
				LoopType.Restart,
				5);
```

## ITweenHandle and Events

By design, most tweens are played automatically once created and cleaned up once completed. This emphasizes a strategy of creating tweens only when needed, avoiding allocating instances of handles to tweens when none may be needed, and avoids requiring by default that users have to manage the lifecycle of a tween. These type of methods will offer `System.Action` callback parameters for when a tween starts and completes to be able to chain relevant functionality to tweens.

However, there are many circumstances where user control over tweens is important, particularly where a user may want to pause, resume, or stop a running tween. This is possible by using the tween method overloads that offer an `out ITweenHandle` parameter. These methods will create tweens that do not play or clean themselves up automatically and require more hands-on managemenent from a user over its lifecycle. Once created, these tweens will remain in the JTween managed data until explicitly recycled. Once a user has recycled an `ITweenHandle`, they should clear any local references to it as it will be reused the next time a user attempts to get another one.

The types of actions a user can execute on an `ITweenHandle` include:
* Add zero or more listeners for when the tween starts.
* Add zero or more listeners for when the tween completes.
* Playing the tween (if this is the first time a user has played the tween, this will invoke any listeners for the started event)
* Pausing the tween.
* Restarting the tween (Rewinds its tween data back to the original values and automatically plays it).
* Rewinding the tween (Rewinds its tween data back to the original values and automatically pauses it. If a tween was already playing, it will be paused and its current state will not be updated until played).
* Stopping the tween (Stops the tween instance and marks it as completed which will invoke any listeners for the completed event).
* Recycle the tween (Once a user has recycled an `ITweenHandle`, any reference to that instance should be cleared).

In addition, the user can actively query for the current state of the tween using the `ITweenHandle` methods:
* `IsPlaying()`
* `IsPaused()`
* `IsCompleted()`

## Non-ITweenHandle API Example

### API

```
public static void Move(
			this Transform transform,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
{
	...
}
```

### Example

```
// This tween will play automatically and once completed playing will clean itself up without user
// management. 
transform.MoveLocal(new Vector3(10, 0, 0), 2, EaseType.BounceOut, LoopType.Restart, 5, OnTweenStart, OnTweenComplete;
```

## ITweenHandle API Example

### API

```
public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
{
	...
}
```

### Example

```
ITweenHandle tweenHandle;
transform.MoveLocal(new Vector3(10, 0, 0), 2, out tweenHandle, EaseType.BounceOut, LoopType.Restart, 5);
```

## Single and Batch Tween APIs
Many API methods exist both as extension methods and on `JTweenControl` for tweening individual transforms. However, where there are many tweens that stop at the same time there is a performance hit for cleaning them up. If starting many tweens on a single frame that have the same duration it may be advantageous to take advantage of the batch APIs on `JTweenControl`. These allow for the creation of many tweens at once whose data is stored in a linear fashion and when completed can be cleaned up much more efficiently. There are some differences to take into account when using these methods, particularly around events and `ITweenHandle`s if used. 

**Single Tween APIs** 
* Started and Completed events fire for this tween instance only (1:1 for events per tween)
* An `ITweenHandle` affects only this tween instance.
* Accepts a single transform parameter as well as single parameters for movement, rotation, and scaling.

**Batch Tween APIs**
* Started and Completed events fire for when the batch of tween instances start and stop/complete (1:X for events to X number of tweens in the batch)
* An `ITweenHandle` reference affects the entire batch of tweens and has the same behavior as it does for a single tween. The batch will start as being paused until played, when paused it will pause every tween in the batch, etc...The batch of data will remain in JTween's managed collections until recycled by a user.
* Accepts an array of transforms as well as arrays for any of the relevant data for movement, rotation, and scaling. Usage is predicated on the arrays having equal length or for sliced versions that the slice is contained within the array's contents; if this is not the case, an assertion will occur.
* Batch methods are available for using an entire array of transforms or only a slice of the array (a linear block of an existing array identified by a start index and length of the array's data from that index that should be used).

### Batch API Example Without Slice

```
public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
{
	...
}
```

### Batch API Example With Slice

```
public void BatchMoveSlice(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
{
	...
}
```

## Tween Collections
More complex chaining or grouping of tweens can be tedious if attempting to do this manually by using either single or batched listeners for Started, Completed events. For this purpose I have created two tween set collections, `ITweenSet` and `ITweenSequence` which help to make this easier by providing a similiar API to `ITweenHandle`, but allows for managing multiple `ITweenHandle` instances at once. Since an `ITweenHandle` could represent either a single tween or batch of tweens, these collections do not distinguish between them and can handle them both equally well.

**NOTE:** For tweens that have been set to infinitely loop, these may cause certain undesired behavior such as certain callbacks not being able to occur or blocking progress in the sequence in the case of `ITweenSequence`. Please make sure if you do add inifnitely looping tweens that you are tracking and managing their their ITweenHandles to avoid these scenarios.

### ITweenSet
`ITweenSet` is an tween collection that allows a user to add X number of `ITweenHandle` instances and be able to seamlessly execute play, pause, stop, rewind, restart, or recycle actions on all of them at once. In addition, it offers the ability to add listeners for when the `ITweenHandles` are first played and when all of them have completed.

Creating a new `ITweenSet` is as simple as calling `JTweenControl.Instance.NewSet()`.

### ITweenSequence
`ITweenSequence` is a tween collection that allows a user to add X number of `ITweenHandle` instances that can be played in sequence. Once the `ITweenSequence` is played, is started event will fire and each `ITweenHandle` will play in the order that they were added. Once all `ITweenHandles` have been played, the completed event will fire. There are a couple of distinctions from `ITweenSet` to take note of:
* Pausing an `ITweenSequence` will pause the currently playing `ITweenHandle` in the sequence if any.
* Restarting an `ITweenSequence` will rewind all `ITweenHandle` instances in the sequence and immediately play the first one.

Creating a new `ITweenSequence` is as simple as calling `JTweenControl.Instance.NewSequence()`.