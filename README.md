# AzureSamples
A collection of  Azure samples targeted to connections with a limited band width. 

Being in touch with the latest Microsoft technologies in a country where Internet connectivity is not qualitatively appropriate are the genesis of this repository.

Another thing is that for the Azure SDK there is no offline installer. So the only alternative is to audit the HTTP requests to the online installer to download the prerequisites in the appropriate order in a place where the connectivity bandwidth is at least 56 Kb.

I’ll share with you the sorted list:

    http://download.microsoft.com/download/0/2/F/02F628CC-6818-462A-B6F4-F78E0E41F7FA/Drop/enu_VS/Preparation_Uninstall_vs_professional/preparation.exe
    http://download.microsoft.com/download/7/4/8/74814E48-0AF7-416A-8109-0F201B921A98/MicrosoftAzureQuickstarts.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureStorageEmulator.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureAuthoringTools-x64.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureAuthoringTools-x64.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureComputeEmulator-x64.exe
    http://download.microsoft.com/download/9/F/7/9F7D3299-9AE1-40BE-B24F-C0E9EB0BE61E/HiveODBC32.msi
    http://download.microsoft.com/download/9/F/7/9F7D3299-9AE1-40BE-B24F-C0E9EB0BE61E/HiveODBC64.msi
    http://az412849.vo.msecnd.net/downloads04/azure-powershell.0.9.7.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureLibsForNet-x64.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/AzureMobileAppsSdkV2.0.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/MicrosoftAzureTools.VS140.exe
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/Microsoft.Azure.HDInsightToolsForVS2015.msi
    http://download.microsoft.com/download/0/F/E/0FE64840-9806-4D3C-9C11-84B743162618/WebToolsExtensionsVS14.msi

Once all the above links have been downloaded you can install on any PC without an internet connectivity.

Samples:
====================================================================================

1. Uploading Large Files
===========================
The work around here is uploading the files by splitting them in chuncks from client side to server side. 
We'll use the javascript library https://github.com/23/resumable.js from client side to make the splitting work.


