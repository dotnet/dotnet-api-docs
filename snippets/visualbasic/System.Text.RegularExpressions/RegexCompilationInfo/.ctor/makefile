<<<<<<< HEAD
all : genFishRegex.exe useFishRegex.exe 

genFishRegex.exe: genFishRegex.vb
	vbc genFishRegex.vb

FishRegex.dll: genFishRegex.exe
	genFishRegex.exe

useFishRegex.exe: useFishRegex.vb FishRegex.dll
	vbc /r:FishRegex.dll useFishRegex.vb

=======
Example1.exe: Example1.vb
        vbc Example1.vb

RegexLib.dll: Example1.exe
        Example1.exe

Example1a.exe: Example1a.vb RegexLib.dll
        vbc /r:RegexLib.dll Example1a.vb
>>>>>>> 888bb64f55349b13f1342f20d22b825c7eb339d7
