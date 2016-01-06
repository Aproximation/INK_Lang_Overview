#include "stdafx.h"
#include <iostream>
#include <string>
#include <Shlwapi.h>
#include <fstream>
#include <sstream>
#include <vector>
#include "FileControler.h"

LPCTSTR filePath;
int rowsNumber = 0;
int charsNumber = 0;
int whiteCharsNumber = 0;
string longestWord = "";

int FileControler::CountWhiteChars(string line)
{
	int counter = 0;
	for each(char c in line)
	{
		if (isspace(c))
		{
			counter++;
		}
	}
	return counter;
}

vector<string> &FileControler::split(const string &s, char delim, vector<string> &elems) {
	stringstream ss(s);
	string item;
	while (getline(ss, item, delim)) {
		elems.push_back(item);
	}
	return elems;
}

vector<string> FileControler::split(const string &s, char delim) {
	vector<string> elems;
	split(s, delim, elems);
	return elems;
}

void FileControler::FindLongestWord(string line)
{
	vector<string> splitted = split(line, ' ');
	for each(string word in splitted)
	{
		if (word.length() > longestWord.length())
		{
			longestWord = word;
		}
	}
}

FileControler::FileControler(LPCTSTR filePath)
{
	ifstream file(filePath);

	int count = 0;
	string line;

	while (getline(file, line))
	{
		FindLongestWord(line);
		whiteCharsNumber += CountWhiteChars(line);
		charsNumber += line.length();
		rowsNumber++;

	}
}