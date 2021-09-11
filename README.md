# bushhidthefacts

A small program that reproduces the "Bush hid the facts" bug on Windows operating systems

## As explained by Wikipedia

Bush hid the facts is a common name for a bug present in some versions of Microsoft Windows, which causes text encoded in ASCII to be interpreted as if it were UTF-16LE, resulting in garbled text. When the string "Bush hid the facts", without newline or quotes, was put in a new Notepad document and saved, closed, and reopened, the nonsensical sequence of Chinese characters "畂桳栠摩琠敨映捡獴" would appear instead.

## About the project

The bug was caused by the Win32 function "IsTextUnicode" which was introduced with an early version of Windows NT. Since the release of Windows Vista, notepad.exe stopped relying on this particular function which has resolved the issue. The function itself still remains a part of the Windows ecosystem and has never been changed or improved ever since. Just like notepad.exe used to do it, this program tries to check if "bush hid the facts" is Unicode.
