# Unity Setup

This project is a starter skeleton for a 2D slap game where the player taps or clicks a face.

## 1. Install Unity

Use Unity Hub and install **Unity 2022.3 LTS**.

The repo includes [ProjectVersion.txt](/Users/wru/DEV/Projects/GitHub/whack/ProjectSettings/ProjectVersion.txt), so using the same version will avoid upgrade prompts.

## 2. Open the Project

In Unity Hub:

1. Click **Open**
2. Pick this folder: `/Users/wru/DEV/Projects/GitHub/whack`
3. Let Unity import and generate the missing project files

## 3. Create the First Scene

Create a new scene named `MainScene` inside `Assets/Scenes`.

Recommended hierarchy:

- `Canvas`
- `EventSystem`
- `GameController`
- `Background`

Inside `Canvas`, create:

- `FaceButton` using a UI `Button` or `Image`
- `SlapFlash` using a full-size semi-transparent red `Image`
- `ScoreText`
- `StatusText`
- `ImagePathInput`
- `LoadAvatarButton`
- `ResetAvatarButton`
- `UploadFeedbackText`

## 4. Add the Scripts

Attach these components:

- `FaceSlapGameController` on `GameController`
- `SlappableFace` on `FaceButton`
- `AvatarFaceView` on `FaceButton`
- `RuntimeAvatarLoader` on `GameController`
- `AvatarUploadPanel` on `Canvas` or another UI manager object

## 5. Wire the Inspector References

### FaceSlapGameController

- Drag `FaceButton` into `Slappable Face`
- Drag `ScoreText` into `Score Text`
- Drag `StatusText` into `Status Text`

### SlappableFace

- Drag the `RectTransform` from `FaceButton` into `Face Visual`
- Drag `SlapFlash` into `Slap Flash`
- Optional: add an `AudioSource` and connect it to `Slap Audio`

### AvatarFaceView

- Drag the `Image` component from `FaceButton` into `Face Image`
- Assign a placeholder face sprite as `Fallback Sprite`

### RuntimeAvatarLoader

- Drag `FaceButton` with `AvatarFaceView` into `Avatar Face View`
- Drag `UploadFeedbackText` into `Feedback Text`

### AvatarUploadPanel

- Drag `ImagePathInput` into `Image Path Input`
- Drag `GameController` with `RuntimeAvatarLoader` into `Runtime Avatar Loader`

## 6. Hook Up Button Events

For `LoadAvatarButton`, add an `On Click` event:

- Target: object with `AvatarUploadPanel`
- Method: `AvatarUploadPanel.LoadAvatarFromInput`

For `ResetAvatarButton`, add an `On Click` event:

- Target: object with `AvatarUploadPanel`
- Method: `AvatarUploadPanel.ResetAvatar`

## 7. Test the Prototype

Enter Play Mode and check:

- Clicking the face increases the score
- The face slightly scales when slapped
- The flash image fades in and out
- Typing a real local `.png` or `.jpg` file path loads a new avatar

## 8. Good Next Steps

Once the skeleton works, build on it in this order:

1. Replace manual file-path input with a real file picker plugin
2. Crop the uploaded image to just the face area
3. Add sound, particles, and combo scoring
4. Add a timer and end screen
5. Save high scores and the last uploaded avatar

## 9. What This Starter Does Not Do Yet

This is intentionally small. It does not yet include:

- A polished art style
- Mobile touch tuning
- Runtime permission prompts for every platform
- A browser-based upload flow for WebGL
- Face detection or auto-cropping

Those are all good next features once the first clickable version is running.
