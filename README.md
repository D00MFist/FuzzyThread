# FuzzyThread

C# code to use Sharpsploit Injector

### Usage
```
1) Generate the XOREncrypt.exe: (i.e. Build-->Configuration Manager--> XOREncrypt--> build)
2) Generate payload.bin: (For CS: Attacks-->Packages-->Payload Generator-->Output Raw-->"Use x64 payload")
3) Run XOR on binary: .\XOREncrypt.exe payload.bin (This creates an encrypted.bin)
4) Add this encrypted.bin to resources of FuzzyThread in visual studio
5) Remove the pdb from the Build settings:
Project → "Name of Project" Properties...
Build -> Advanced → "Advanced Build Settings
Set Output - Debug info to "None"
6) Add Sharpsloit w/ Injector API as a reference (https://king-sabri.net/how-to-compile-embed-and-use-sharpsploit/)
7) Build FuzzyThread: (i.e Build-->Configuration Manager--> FuzzyThead--> build)
8) copy file and rename
```

Note:
```
To further customize you can make a new key:
Change the key: key in FuzzyThread: Headers.CS and XOREncrypt: Program.CS  
```

### References:

https://github.com/djhohnstein/CSharpCreateThreadExample
https://king-sabri.net/how-to-compile-embed-and-use-sharpsploit/
https://dotnetnsqlcorner.blogspot.com/2014/04/how-to-disable-generating-pdb-files.html
https://twitter.com/_RastaMouse/status/1228445657729396736/photo/1
https://github.com/cobbr/SharpSploit/tree/52ad861d98d75bb0a7f6cd9d421dc8a8463adc08