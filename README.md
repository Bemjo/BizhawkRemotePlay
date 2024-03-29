# Description
Remote control tool for bizhawk, allows various services to send text command sequences representing gamepad controller buttons.  

## Service Support
* Twitch Chat  
* Discord Channels  

## Installation
Copy this into your Bizhawk installation folder.  
It places this plugin into Bizhawk/ExternalTools and required library DLLs in Bizhawk/dll  

## API Keys
In order to use this plugin, you will need your own API/bot keys for each service you wish to use.  
You'll need to enter these details inside of the tool itself.  

### Twitch
For twitch you will need a username, and your oauth key for the TMI.
You can generate a key here: https://twitchapps.com/tmi/
PLEASE REMOVE THE oauth: prefix

### Discord
This does NOT WORK for large channels >= 100 users due to discords API limits. A fix to this may come sometime in the future if there is ever any demand.  

For discord you will need your own configured bot and token.  
See [Creating an App](https://discord.com/developers/docs/getting-started#step-1-creating-an-app) for more details.  

You will need your Discord Channel ID, not the channel name! To get this, you must enable developer mode, right click on the channel the bot should listen to, and select Copy ID.  

See https://www.remote.tools/remote-work/how-to-find-discord-id for a guide if you need it.  

## Syntax & Usage
Syntax: See https://pastebin.com/Uxn6zREQ  

## Build Requirements
Requires a copy of Bizhawk, and various Bizhawk DLLs  
https://github.com/TASEmulators/BizHawk/releases/latest  

### Libraries:
[Discord.Net](https://github.com/discord-net/Discord.Net#-installation)  
[TwitchLib](https://github.com/TwitchLib/TwitchLib#installation)  
[AsyncEx](https://github.com/StephenCleary/AsyncEx#asyncex)
