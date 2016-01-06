#pragma once
using namespace std;

class FileControler
{
	private:
		vector<string> &split(const string &s, char delim, vector<string> &elems);

	public:
		LPCTSTR filePath;
		int rowsNumber;
		int charsNumber;
		int whiteCharsNumber;
		string longestWord;

		FileControler(LPCTSTR filePath);
		void FindLongestWord(string line);
		vector<string> split(const string &s, char delim);

		int CountWhiteChars(string line);
};