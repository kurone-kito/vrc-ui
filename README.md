# ![black.kit.vrcui: Unofficial uGUI theme like the VRChat for VRChat worlds](https://kurone-kito.github.io/vrc-ui/banner.png)

Language: **🇬🇧** | [🇯🇵](https://github.com/kurone-kito/vrc-ui/blob/main/README.ja.md)

VRChat comes with the stress of “learning the world-specific UI”.

We have always wanted to help players who get lost in the different UIs in
different worlds. If we can freely use the same UI within a world as the
standard VRChat one, it may help players and world creators concentrate on
“enjoying the world” rather than “learning or remembering how to operate
the world”.

This “VRCUI” is a VRChat asset created for such creators.

## 🛠 Requirements

This package is built for **Unity 2022.3** and newer. We recommend using
Unity **2022.3** or later with the
[VRChat Creator Companion](https://docs.vrchat.com/docs/creator-companion)
and VPM to install the package.

## 💡 Features

- Buttons
- Cards
- Dropdowns
- Scrollbars / Sliders
- Slide shows
- Toggles
- ... and more!

## ▶ Getting Started

### 1. Import the registry via the VRChat Creator Companion (VCC)

Visit the **[VPM Catalogue page](https://kurone-kito.github.io/vpm/)** and
click on the **Add to VCC** button.

### 2. Import the package to your project

1. Click on the "Manage Project" button in the VCC
2. Find the "black.kit.vrcui" package and click on the "(+) Add package"
   button

### 3. Use the package, enjoy :D

1. Open the `Packages/black.kit.vrcui/Runtime/Prefabs` folder.
2. Drag the desired prefab into your Canvas. Prefabs are organised under
   *Atoms*, *Molecules* and *Organisms*.
3. You can also attach the scripts from these prefabs to your own objects.

#### Examples

- **Fps** – Place `Organisms/Status/Fps.prefab` to display frame rate.
  The `Fps` component updates the text every interval.
- **Progress** – Use `Organisms/Status/Progress.prefab` and change its
  `Value` property from UdonSharp to show progress.

(To be added)

## Dependencies

If you use the project via the VCC, import automatically the following
dependencies:

- [VRC Icons (black.kit.launchpadicon)](https://github.com/kurone-kito/launchpad-icons)
- [UdonSharp Toybox (black.kit.toybox)](https://github.com/kurone-kito/udonsharp-toybox)

## Contributing

Welcome to contribute to this repository! For more details, please refer to
[CONTRIBUTING.md](https://github.com/kurone-kito/vrc-ui/blob/main/.github/CONTRIBUTING.md).

## 🛠 Using `git vrc` Filter

This project uses a custom git filter named `git vrc` to normalize Unity
files such as `.asset`, `.prefab`, and `.unity`. The filter removes
unstable data so diffs stay readable and merges remain smooth.

### 1. Install the `git-vrc` package

```sh
cargo install --locked --git 'https://github.com/anatawa12/git-vrc.git'
git vrc install --config --global
```

### 2. Make the `.gitconfig` file available for referencing from local `.git/config`

```sh
git config include.path '../.gitconfig'
```

The `.gitattributes` file in this repository already applies the filter to
Unity YAML files.

## License

Copyright (c) Kuroné Kito (黒音キト)

This project is a dual license with the following options:

- [MIT License](https://opensource.org/licenses/MIT)
- [Creative Commons CC BY 4.0](https://creativecommons.org/licenses/by/4.0/)

**The DEFAULT LICENSE applied is MIT**. You can use it under the CC BY 4.0
license by opting in in any way when incorporating it into your work.

The CC BY 4.0 license is a remnant from when this library was distributed
under the CC BY-NC 4.0 license and is retained for compatibility.
