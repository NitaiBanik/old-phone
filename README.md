# Old Phone Pad

This is a C# implementation of an old mobile phone keypad simulator.

- Converts sequences of digit presses into corresponding letters.
- Supports special operations like backspace (`*`) and last digit of input as (`#`)

## Here is the keypad mapping

| Digit | Characters |
| ----- | ---------- |
| 2     | ABC        |
| 3     | DEF        |
| 4     | GHI        |
| 5     | JKL        |
| 6     | MNO        |
| 7     | PQRS       |
| 8     | TUV        |
| 9     | WXYZ       |

### Example

```csharp
OldPhone oldPhone = new OldPhone();
string output =  oldPhone.OldPhonePad("227*#") => B
 output = oldPhone.OldPhonePad("8 88777444666*664#") => TURING
 output = oldPhone.OldPhonePad("9999 9999 9999 9999#") => ZZZZ
 output =  oldPhone.OldPhonePad("23456789#") => ADGJMPTW
 output = oldPhone.OldPhonePad("***   #") =>
 output = oldPhone.OldPhonePad("***   2#") => A
 output = oldPhone.OldPhonePad("***#") =>
 output = oldPhone.OldPhonePad("#") =>

```
