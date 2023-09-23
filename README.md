# Password Generator in C#

![passwordgen](https://github.com/joelb-services/Password-Generator/assets/144958989/4726b241-9261-4c2e-ab64-24cc9fac7704)

Welcome to the Password Generator project, a versatile tool for creating strong and customizable passwords in C#. Safeguard your online accounts and sensitive information with ease.

## Features
- **Customizable Passwords:** Generate passwords with different character types:
  - Uppercase Letters
  - Lowercase Letters
  - Numbers
  - Symbols
    
- **Variable Length:** Set the password length from 1 to 50 characters.

- **Copy and Generate:** Copy generated passwords to your clipboard and create as many as you need.

## Dependencies
This project uses the SiticoneUI framework for enhancing the user interface. You can download the SiticoneUI DLL from the official website: [SiticoneUI](https://siticoneframework.com/).

## How to use

1. **Clone or Download:** Clone this repository or download the source code to your local machine.

2. **Build the Project:** Use Visual Studio 2022 or your preferred C# development environment to build the project.

3. **Add SiticoneUI Reference:**

   - Open your project in Visual Studio 2022.

   - Right-click on "References" in the Solution Explorer and choose "Add Reference..."

   - Click the "Browse" button and locate the downloaded SiticoneUI DLL.

   - Click "Add" and then "OK" to add the SiticoneUI reference to your project.

4. **Launch the Application:** Open the generated executable.

5. **Customize Your Password:**
   - Select the character types you want.
   - Adjust the password length using the slider.

6. **Generate Password:** Click the "Generate Password" button to create a secure password.

7. **Copy to Clipboard:** Click the "Copy to Clipboard" button to save the password for immediate use.

8. **Repeat as Needed:** Generate multiple passwords with different configurations.

## Code Examples:

### Character Sets
```csharp
private const string Numbers = "0123456789";
private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
private const string Symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?/";
```

### Password Generation
```csharp
StringBuilder password = new StringBuilder(length);
Random random = new Random();

for (int i = 0; i < length; i++)
{
    int randomIndex = random.Next(0, characterSet.Length);
    password.Append(characterSet[randomIndex]);
}

return password.ToString();
```
