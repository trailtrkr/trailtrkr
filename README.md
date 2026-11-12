# trailtrkr

# Developer: Wright Ceresa, Sean Sikora

# Developer: William Allemang

# Developer: Avi Raj 

## Opening Project
1. Download Visual Studio 2026 Community
2. Install the following packages: 
	- Asp.Net & Web Development
	- .Net Maui mobile 
3. Clone repository to local computer
4. Visual studio -> Open Folder/Solution -> Choose top level /TrailTrkr

## Running Locally - Web & Mobile
1. Select TrailTrkr.App or TrailTrkr.Web in the start up project drop down menu (top middle of toolbar, left of green play button)
2. Web:
    - Select TrailTrkr.Web
    - Ensure Green play button says "https"
    - Hit green play button
    - The website should start and launch
3. App:
    - Select TrailTrkr.App 
    - Plug your phone into laptop, enable debug / developer settings, and allow file transfer.
    - Android
        - With phone plugged in and in developer mode, click green play button drop down and you should see "Android Local Devices"
        - Expand local devices, and find your phone
        - Play button should update with something similar as "Samsung SM-S91U (Android 16.0 - API 36)". This is my phone. 
        - Click play button with phone plugged in & selected, and the app will launch automatically once installed
    - Apple
        - Requires up to date Mac OS & XCode.
        - Apple development is tricker to setup than Android, I can assist anytime. 
    - Note: Once the app is installed, and you're done debugging, you can unplug your phone and still use the app on your phone. 

## Proposed Branching Strategy, modify as needed
- Keep main clean
	- Only merge via PR Features & Bugfixes into main
	- PRs must be approved by 2 other group members? (Maybe all?)
- Develop features in Features/ branches
	- Create local branch off main, name Features/[FeatureName]
	- This allows branches to be organized within the Visual Studio UI and other branch tools
- Fix bugs in Bugfix/ branches
	- Create local branch off main or specific branch, name Bugfix/[BugName]
- Releases
	- After tests, we will have 4 main Release branches: 
	1. Release/Web
	1. Release/Api
	2. Release/Mobile/Android
	3. Release/Mobile/Ios
	- These branches will contain RELEASED code for the website, API, and mobile versions. 
	- Becareful merging into these branches - these will be configured to automatically push Web and API code changes to our google cloud in the future.
		- Mobile Releases will be done manually as one-off releases as needed	
