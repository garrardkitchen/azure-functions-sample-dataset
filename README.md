# Getting started

```powershell
$NAME="<functionapp-name>"
$RG="<resource-group>"
$SA="<storage-account-name"
```

```powershell
az functionapp create --consumption-plan-location uksouth --name $NAME --os-type Windows --resource-group $RG --runtime dotnet --runtime-version 6 --functions-version 4 --storage-account $SA 
```

```powershell
az functionapp config appsettings set --name $NAME --resource-group $RG --settings "FUNCTIONS_WORKER_RUNTIME=dotnet-isolated"

# FYI, if you run this command after deployment, the function will fail so will need to redeploy
az functionapp config appsettings set --name $NAME --resource-group $RG --settings "WEBSITE_RUN_FROM_PACKAGE=1"

```powershell
dotnet publish -c release
```

```powershell
Compress-Archive -Path ./AzureFunctionSampleDataset/bin/Release/net6.0/publish/* -Update -DestinationPath ./AzureFunctionSampleDataset/obj/publish.zip
```

```powershell
az functionapp deployment source config-zip -g $RG -n $NAME --src ./AzureFunctionSampleDataset/obj/publish.zip
```
