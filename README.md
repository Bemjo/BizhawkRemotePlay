# Description
Remote control tool for bizhawk, allows various services to send text command sequences representing gamepad controller buttons.  

## Service Support:
* Twitch Chat  
* Discord Channels  

## Installation
Copy the Bizhawk folder over your local copy of Bizhawk.  
It places this plugin into Bizhawk/ExternalTools and required library DLLs in Bizhawk/dll  

## API Keys & Configuration
In order to use this plugin, you will need your own API/bot keys for each service you wish to use.  

You can fill out a JSON file with the folling entries, replace the relevant sections with your own applicable data.  

```
{
	"twitchUsername": "Your Twitch Username",
	"twitchToken": "Your twitch chat token",
	"discordToken": "Your discord bot token"
}
```  

### Twitch
For twitch you will need a username, and your oauth key for the TMI.
You can generate a key here: https://twitchapps.com/tmi/
PLEASE REMOVE THE oauth: prefix

### Discord
This does NOT WORK for large channels >= 100 users due to discords API limits. A fix to this may come sometime in the future if there is ever any demand.  

For discord you will need your own configured bot and token.  
See [Creating an App](https://discord.com/developers/docs/getting-started#step-1-creating-an-app) for more details.

## Syntax & Usage
Syntax: See https://pastebin.com/Uxn6zREQ  

## Build Requirements
Requires a copy of Bizhawk, and various Bizhawk DLLs  
https://github.com/TASEmulators/BizHawk/releases/latest  

Libraries:  
[Discord.Net](https://github.com/discord-net/Discord.Net#-installation)  
[TwitchLib](https://github.com/TwitchLib/TwitchLib#installation)  
[AsyncEx](https://github.com/StephenCleary/AsyncEx#asyncex)
