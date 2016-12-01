tools\vs-build-all.exe -debug -release -m *
if %nopause%==true goto end
pause
:end