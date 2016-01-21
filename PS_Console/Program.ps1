#
# Script.ps1
#
 param (
	[Parameter(Mandatory = $true)] [String] [ValidateNotNullOrEmpty()] $filePath #opcjonalnie $filePath = $(throw "Parameter -filePath is required.") // czyli jesli nie podamy parametru, to zostanie mu przypisana wartość throw exception

 )

 BEGIN{
 #if((Get-PSSnapin | Where {$_.Name -eq "Microsoft.SharePoint.PowerShell"}) -eq $null) {
 #   Add-PSSnapin Microsoft.SharePoint.PowerShell;
 #}
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
