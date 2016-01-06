#
# Script.ps1
#
 param (
	[Parameter(Mandatory = $true)] [String] [ValidateNotNullOrEmpty()] $filePath
 )

 BEGIN{
    $ScriptsDir = Resolve-Path .\
	Import-Module ("{0}\FileControler.psm1" -f $ScriptsDir) -ea Stop
 }

 PROCESS{
	$whiteChars = StartProcessing -FilePath $filePath
	Write-Host ("Liczba wierszy: {0}" -f (Get-RowsNumber))
	Write-Host ("Liczba znaków: {0}" -f (Get-CharsNumber))
	Write-Host ("Liczba białych znaków: {0}" -f $whiteChars)
	Write-Host ("Nadłuższy wyraz to: {0}" -f (Get-LongestWord))
 }
