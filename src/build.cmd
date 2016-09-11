REM Build Solution
SET CONFIGURATION=%1
set PATH_SOURCE_SLN="Amogram.Common.DateTime\Amogram.Common.DateTime.csproj"
if [%1]==[] (
  SET CONFIGURATION=net451
)
MSBuild %PATH_SOURCE_SLN% /p:Configuration=%CONFIGURATION%