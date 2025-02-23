# How to extract the Unity Serial from your .ulf file

On macOS or Linux:
`cat Unity_lic.ulf | grep DeveloperData | sed -E 's/.*Value="([^"]+)".*/\1/' | base64 --decode`

On Windows using Powershell:
`Get-Content Unity_lic.ulf | Select-String -Pattern 'DeveloperData' | ForEach-Object { $_ -replace '.*Value="([^"]+)".*', '$1' } | [System.Convert]::FromBase64String($_)`

https://game.ci/docs/gitlab/activation/
