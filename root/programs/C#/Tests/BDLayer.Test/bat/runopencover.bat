..\packages\OpenCover.4.5.2506\OpenCover.Console.exe -target:runtests.bat -register:user -output:BDLayer.xml
..\packages\ReportGenerator.1.9.1.0\reportgenerator.exe -reports:BDLayer.xml -targetdir:coverage