
# App Version Validator

The `VersionValidator` class is a utility for Unity projects that enables the automatic retrieval of the latest application version from the respective app store. It supports both Android (Google Play Store) and iOS (Apple App Store) platforms, making it a versatile tool for developers aiming to compare the current app version with the store's latest to prompt users for updates or for internal checks.

## Features

- **Platform-Specific Version Retrieval:** Utilizes platform-specific URLs and parsing techniques to fetch the latest version information directly from Google Play Store or Apple App Store.
- **Asynchronous Operations:** Leverages `async/await` for non-blocking network requests.
- **Error Handling:** Provides basic error handling and logging capabilities to aid in debugging and operational reliability.

## Requirements

- Unity 2018.4 LTS or later (recommended for full `async/await` support).
- .NET 4.x scripting runtime version.

## Installation

To integrate the `VersionValidator` into your Unity project, follow these steps:

1. Ensure that your project is set up with .NET 4.x compatibility (Edit -> Project Settings -> Player -> Other Settings -> Scripting Runtime Version).
2. Copy the `VersionValidator.cs` script into your project's `Scripts` directory or any other appropriate location.

## Usage

### Android

```csharp
string bundleId = "com.example.app"; // Replace with your actual bundle ID
string latestVersion = await VersionValidator.GetVersion(bundleId);
Debug.Log($"Latest version on Play Store: {latestVersion}");
```

### iOS

```csharp
string bundleId = "com.example.app"; // Replace with your actual bundle ID
string latestVersion = await VersionValidator.GetVersion(bundleId);
Debug.Log($"Latest version on App Store: {latestVersion}");
```

## Notes

- Ensure that your app's bundle ID matches exactly with what is registered on the Google Play Store or Apple App Store.
- Network errors and parsing failures are logged as warnings or errors in the Unity console. Handle these appropriately in your application logic.

## Contributions

Contributions are welcome. Please submit pull requests or open issues to suggest improvements or report bugs.
