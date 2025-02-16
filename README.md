# HttpRequest  
This repository stores a windows application project (Desktop + .NET + C#). The application, called Http Request, provides a gui means of sending http requests and displaying the response data in useful ways. The public (instead of private) nature of this repository is to allow for a showcase of my development ability. It is not for software distribution. It is for exploring, reading, or learning from. To that extent, this repository will not include the future application's full source code. It is, however, a starting point. The current application is in the releases for executable download.

<img src="HttpRequest.png" width="25%">


## License  
The use of this software and/or its code is licensed to robhowe-A's (account) owner [see below copyright].  

##  Where do I begin?  
- The solution files were created in visual studio 2022.  
- An executable of the application is made up of the current alpha release. Just click on the release tag on the code directory page to go to the application download location.
- It's target is for Windows x64 desktop.  

Http Request is a working tool, not an attractive or refined display product. The styling is basic and default in many elements. Developed in Forms style, this app is responsive on windows desktops - it expands or collapses menus on request/need - and dynamically adapts its controls based on different situations a request encounters. I've tested the app and am happy with 1920 x 1920 max dimensions. It is useful with different data in different sizes, both large or small. Also, Forms seems to fit that.  

1. Download the compression folder [here](https://github.com/robhowe-A/WinHttpRequest/releases/)  
2. Unzip the contents  
3. Double-click the executable  
4.(Possible instruction leaf) Dotnet 9 is required for >v2 of this application; starting the .exe may prompt for runtime download. Follow the download, confirm the download hash, and install.  
5.(Possible instruction leaf) Tell windows the app is okay to run by clicking "Run anyway" (first, click more info to show the publisher. Don't worry, I'm the developer and this happens because the publisher isn't known by your computer.)  
6. That's it! You now have the repository's application skipping the need to build and publish.  

<img src="HttpRequest_v1.9.1-alpha.png" width="35%">


## How to use the application  
Enter any url and select a method for the request. The default is a GET request. Use the options or change the input parameters for your requests. Some functionality is for developement purposes and may not function.  

--------  
&copy; 2024, Robert Howell. All rights reserved.  

#### Tags - (optional)Updates  
<details>
<summary>Version 1.3 - 1.5</summary>
9-28-2024: v1.3.3-alpha  
9-29-2024: v1.3.4-alpha - PATCH + DELETE added  
9-30-2024: v1.4.1-alpha - advanced requests  
9-30-2024: v1.4.2-alpha - advanced form sizing  
10-1-2024: v1.4.3-alpha - name-value key  
10-6-2024: v1.5.1-alpha - advanced details view  
10-6-2024: v1.5.2-alpha  
10-6-2024: v1.5.3-alpha  
</details>
<details>
<summary>Version 1.6 - 1.8</summary>
10-13-2024: v1.6.1-alpha - performance measure  
10-19-2024: v1.6.2-alpha - "delete" menustrip  
10-19-2024: v1.6.3-alpha  
10-20-2024: v1.6.4-alpha - http version option functionality  
10-22-2024: v1.6.5-alpha - progress bar  
10-22-2024: v1.6.6-alpha - http/3  
11-18-2024: v1.6.7-alpha - embedded user agent  
12-16-2024: v1.7.1-alpha - link requests(via html head)  
12-17-2024: v1.7.2-alpha - html subsequents  
12-18-2024: v1.7.3-alpha - html css subsequent  
12-19-2024: v1.7.4-alpha - status code each tab  
12-21-2024: v1.7.5-alpha - status code advanced detail  
12-21-2024: v1.7.6-alpha - item detail adv view  
1-6-2025: v1.8.1-alpha - DELETE method request body  
1-6-2025: v1.8.2-alpha - adv window open bug fix  
1-7-2025: v1.8.3-alpha - clear + copy buttons for individual response tab  
1-8-2025: v1.8.4-alpha - adv buttons change visibility behavior  
1-8-2025: v1.8.5-alpha - adv button tag data change on exception  
</details>  

1-12-2025: v1.8.6-alpha - Request address data detail  
1-12-2025: v1.8.7-alpha - Request address data detail full sizing  
1-13-2025: v1.8.8-alpha - Adanced option "Allow auto redirect"  
1-14-2025: v1.8.9-alpha - Advanced detail addition  
1-16-2025: v1.8.10-alpha - Content type header tool tip  
1-16-2025: v1.8.11-alpha - Data grid view row cleanup exception fix  
1-18-2025: v1.8.12-alpha - Content-Type header without request message body added  
1-24-2025: v1.9.1-alpha - XML indented print  
1-27-2025: v1.9.2-alpha - Remove adv view on request form change (allow redirect toggle)  
2-3-2025: v1.9.3-alpha - Duplicate Host header show error in data grid  
2-14-2025: v2.0.0-alpha - .NET 9 desktop version (GUI ONLY... use v1 release for developed functions)  
2-14-2025: v2.0.1-alpha - Prevent app opening if login is not selected  
2-16-2025: v2.0.2-alpha - Styles and view function setup  
