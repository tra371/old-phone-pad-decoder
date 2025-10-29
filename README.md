# OldPhonePadDecoder

A simple C# console application and test suite to decode "Old Phone Pad" numeric button sequences into text.

---

## Features

- Decodes space-separated digit groups (e.g. `"4433555 555666#"` → `"HELLO"`).
- Supports delete action via `*` (simulating backspace on old mobile keypads).
- Skips and warns for any unknown key sequences.
- Handles edge cases and robust to malformed input.
- Tested with xUnit in a separate test project.

---

## Usage

### Prerequisites

- .NET 8.0 SDK or later
- [Optional] xUnit CLI for running tests

### Running the Application

```
cd CodingChallenge
dotnet run
```

Edit `Program.cs` to change or extend sample inputs. Can be switched to CLI mode with user input by uncommenting the commented part in `Main()`.

### Running the Tests

```
cd CodingChallenge.Tests
dotnet test
```

---

## Project Structure

```
CodingChallenge/ # Main application project
└── Program.cs
└── OldPhonePadDecoder.cs

CodingChallenge.Tests/ # Test project
└── OldPhonePadDecoderTests.cs

README.md
```

---

## Example

```
Input: 4433555 555666#
Output: HELLO

Input: 227*#
Output: B

Input: 0#
Warning: '0' not found in phonePad dictionary. Skipping.
Output:
```

---

## How it works

- Each group of repeated digits (e.g. "222") maps to a letter (e.g. "c").
- `*` deletes the current input group.
- `#` signifies the end of the input sequence.
- Invalid key sequences are skipped with a warning printed to the error stream.

---

## License

MIT
