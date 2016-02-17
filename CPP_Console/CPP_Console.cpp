// CPP_Console.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <Shlwapi.h>
#include <fstream>
#include <sstream>
#include <vector>
#include "FileControler.h"
using namespace std;

bool FileExists(LPCTSTR szPath)
{
	DWORD dWord = GetFileAttributes(szPath);

	return (dWord != INVALID_FILE_ATTRIBUTES &&
		!(dWord & FILE_ATTRIBUTE_DIRECTORY));
}

int main()
{
	string path;
	cout << "Podaj sciezke do pliku:";
	getline(cin, path);
	wstring wsTmp(path.begin(), path.end());
	const wchar_t* filePath = wsTmp.c_str();
	if (FileExists(filePath))
	{
		//cout << "\230cie\276ka do pliku prawid\210owa";
		FileControler fc(filePath);
		printf("Liczba wierszy: %d\n", fc.rowsNumber);
		printf("Liczba znaków: %d\n", fc.charsNumber);
		printf("W tym bia\210ych znak\242w: %d\n", fc.whiteCharsNumber);
		cout << "Najd\210u\276sze s\210owo:" << fc.longestWord << endl;
	}
	else
	{
		printf("B\210\251dna \230cie\276ka do pliku\n");
	}
	
	getchar();
    return 0;
}