#
# FileControler.psm1
#

#Reading values is from outside the script is imposibru. The nice workaround is to build file with variables, like below:
# $MyVar = "Default"
#And then just invoke it by command
# . "<pathToScriptFile>" 
#ie: . "C:\Scripts\ConfigVariables.ps1"
$script:rowsNumber = 0;
$script:charsNumber = 0;
$script:longestWord = "";
$filePath
$lines


function StartProcessing{
	param(
		[parameter (mandatory=$true)][string]$filePath
		)

	BEGIN{
		$ScriptsDir = Resolve-Path .\
		If (Split-Path $filePath -IsAbsolute) {
			$filePath = Resolve-Path -Path $filePath -ErrorAction Stop
		} else {
			$filePath = Resolve-Path -Path (Join-Path $ScriptsDir $filePath) -ErrorAction Stop
		}
	}
	
	PROCESS{
		$lines = Get-Content $filePath
		
		$script:rowsNumber = $lines.Length
		$script:charsNumber = $lines | ForEach-Object { ($_ | Measure-Object -Character).Characters}
		$script:charsNumber = ($script:charsNumber | Measure-Object -Sum).Sum
		return CountWhiteChars
	}

	END{
	}
}

Function CountWhiteChars{
	$charsWOWhiteSpaces = $lines | ForEach-Object {($_ | Measure-Object -IgnoreWhiteSpace -Character).Characters}
	$charsWOWhiteSpaces = ($charsWOWhiteSpaces | Measure-Object -Sum).Sum
	$whiteCharsNumber = $script:charsNumber - $charsWOWhiteSpaces
	$script:longestWord = FindLongestWord
	return $whiteCharsNumber
}

Function FindLongestWord{
	$word = ""
	ForEach ( $line in $lines )
	{
		$splitted = $line.Split(' ')
		for($i=0; $i -le $splitted.Length; $i++){
			if ($word.Length -le $splitted[$i].Length){
				$word= $splitted[$i]
				}
		}
	}
	return $word
}

Function Get-RowsNumber{
	return $script:rowsNumber
}

Function Get-CharsNumber{
	return $script:charsNumber
}

Function Get-LongestWord{
	return $script:longestWord
}