# 🐱 VPM Project template for VRChat World

My template for the VPM project (for VRChat worlds creation)

## ▶ Getting Started

### 1. Import the registry via the VRChat Creator Companion (VCC)

(To be added)

### 2. Import the package to your project

(To be added)

### 3. Use the package, enjoy :D

(To be added)

## 🤖 Setting up the Automation

Create a repository variable with the name and value described below.
For details on how to create repository variables, see [Creating Configuration Variables for a Repository](https://docs.github.com/en/actions/learn-github-actions/variables#creating-configuration-variables-for-a-repository).
Make sure you are creating a **repository variable**, and not a **repository secret**.

- `PACKAGE_NAME`: the name of your package, like `com.vrchat.demo-template`.

Finally, go to the "Settings" page for your repo, then choose "Pages", and look for the heading "Build and deployment". Change the "Source" dropdown from "Deploy from a branch" to "GitHub Actions".

That's it!
Some other notes:

- We highly recommend you keep the existing folder structure of this template.
  - The root of the project should be a Unity project.
  - Your packages should be in the "Packages" directory.
  - If you deviate from this folder structure, you'll need to update the paths that assume your package is in the "Packages" directory on lines 24, 38, 41 and 57.
- If you want to store and generate your web files in a folder other than "Website" in the root, you can change the `listPublicDirectory` item [here in build-listing.yml](.github/workflows/build-listing.yml#L17).

## License

This repository is licensed under the [MIT License](LICENSE).
