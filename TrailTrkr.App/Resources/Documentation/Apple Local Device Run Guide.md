# Apple Local Device Run Guide

# Why?

Apple developer code uses a code-signing certificate that verifies a digital identity that checks that an app has been created and has not been altered before signing it.

# Steps

## Local Testing on a Real Device

### Xcode Native Project

1. Open project in Xcode on your Mac
2. In Xcode → Settings → Accounts
3. Click + and sign in with a regular Apple Account
    
    <aside>
    <img src="https://app.notion.com/icons/alert_red.svg" alt="https://app.notion.com/icons/alert_red.svg" width="40px" />
    
    It will show up as a Personal team
    
    </aside>
    
4. Select your specific project
5. Go to the Signing & Capabilities tab
6. Check Automatically manage signing and choose your personal Team
7. Plug your iPhone or iPad into your Mac via USB and select it as your run destination in the middle of the top bar.
8. Before running ensure Developer Mode is running on your handheld device
9. Click Run on your Mac
10. On your handheld go to Settings → General → VPN & Device Management
11. Under developer app tap trust so that the device allows your app to launch.
    
    <aside>
    <img src="https://app.notion.com/icons/alert_red.svg" alt="https://app.notion.com/icons/alert_red.svg" width="40px" />
    
    Developer mode can be turned on and off after this whenever you are developing. You do not need to trust the app again if all is good. But if the app does not launch check back.
    
    </aside>
    

### Rider Project

1. Open project in Rider
2. Find your `.csproj` file in Rider
3. Identify your `<ApplicationId>`  and note down the value. Usually something like `com.companyname.myproject` 
4. Now we have to create a dummy project in Xcode.
    1. Open Xcode
    2. In the top menu bar click File → New → Project
    3. Select App and if the option presents iOS and click Next
    4. Delete the Swift application in the default library and keep the project.
    5. Go to the signing and capabilities tab
    6. For your product name or project name type anything
    7. For Team select the free personal team after signing in.
    8. Remember that at the top menu of Xcode where it says App → MacOs or App → iOS make sure it is iOS or your connected handheld device.
    9. In the Organization Identifier type in the `<ApplicationID>` 
    10. Once the Run button is active click run.
    11. This will take a while so be patient
    12. After that repeat steps 8, 10, and 11 from the ‘Xcode native project instructions’
    13. Be wary that Xcode will fail and that is OK
    14. If you want to be sure in the error you will notice the log reached the IDEInstall CoreDeviceWorker stage.
5. Feel free to delete the Xcode project after this step.
6. Now quit Xcode completely
7. Restart Rider
8. Verify the `<ApplicationId>` again.
9. Select the connected physical iPhone in Rider’s top device dropdown and click Run
10. It now runs!