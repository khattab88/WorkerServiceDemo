# WorkerServiceDemo

Create a worker service, configure it, and how to deploy it to a machine.

## Steps:
1. publish service (for example "WebSiteStatus")
2. (Windows) install service as windows service 

   (Powershell as admin) `sc.exe create WebSiteStatus binpath= c:\temp\workerservice\WebSiteStatus.exe start= auto`

3. (Optional) uninstall service

    (Powershell as admin) `sc.exe delete WebSiteStatus`




Reference: https://www.youtube.com/watch?v=PzrTiz_NRKA&t=1724s&ab_channel=IAmTimCorey
